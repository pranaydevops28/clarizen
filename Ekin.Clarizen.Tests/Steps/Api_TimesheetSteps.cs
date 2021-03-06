﻿using System.Linq;
using Ekin.Clarizen.Tests.Context;
using TechTalk.SpecFlow;
using Xunit;

namespace Ekin.Clarizen.Tests.Steps
{
    [Binding]
    public class Api_TimesheetSteps : BaseApiSteps
    {
        public Api_TimesheetSteps(BaseContext context) : base(context)
        {
        }

        [Given(@"I call MissingTimesheets for testuser between '(.*)' and '(.*)' inclusive")]
        public void GivenICallMissingTimeSheetsForTestUserBetweenAndInclusive(string startDate, string endDate)
        {
            GetMissingTimeSheets(startDate, endDate, Context.UserId);
        }

        [Given(@"I get the workpattern for the test user")]
        public void GivenIGetTheWorkPatternForTheTestUser()
        {
            var actual = Context.Api.GetCalendarInfo(Context.UserId);
            Assert.Null(actual.Error);
            Context.SUT = actual;
        }

        [Then(@"there are (.*) missing timesheets")]
        public void ThenThereAreEntities(int expectedCount)
        {
            var actual = (Data.getMissingTimesheets)Context.SUT;
            Assert.Equal(expectedCount, actual.Data.missingTimesheets.Count());
        }

        private void GetMissingTimeSheets(string startDate, string endDate, string userId)
        {
            var start = TestHelper.ConvertToDateTime(startDate);
            var end = TestHelper.ConvertToDateTime(endDate).AddDays(2).AddMilliseconds(-30);

            var actual = Context.Api.GetMissingTimesheets(userId,
                start,
                end);
            Assert.Null(actual.Error);
            Context.SUT = actual;
        }
    }
}