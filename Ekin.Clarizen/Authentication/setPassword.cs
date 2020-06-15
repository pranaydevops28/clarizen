﻿using System;
using System.Threading.Tasks;

namespace Ekin.Clarizen.Authentication
{
    public class setPassword
    {
        public bool IsCalledSuccessfully { get; set; }
        public string Error { get; set; }
        public request BulkRequest { get; set; }

        public setPassword(Request.setPassword request, CallSettings callSettings)
        {
            Call(request, callSettings);
        }
        public async Task Call(Request.setPassword request, CallSettings callSettings)
        {
            // Set the URL
            string url = (callSettings.isBulk ? string.Empty : callSettings.serverLocation) + "/authentication/setPassword";

            if (callSettings.isBulk)
            {
                this.BulkRequest = new request(url, requestMethod.Post, request, null);
                return;
            }

            // Call the API
            Ekin.Rest.Client restClient = new Ekin.Rest.Client(url, callSettings.GetHeaders(), callSettings.timeout.GetValueOrDefault(), callSettings.retry, callSettings.sleepBetweenRetries);
            restClient.ErrorType = typeof(error);
            Ekin.Rest.Response response = await restClient.Post(request, callSettings.serializeNullValues);

            // Return result
            if (response.Status == System.Net.HttpStatusCode.OK)
            {
                this.IsCalledSuccessfully = true;
            }
            else if (response.InternalError != null)
            {
                this.IsCalledSuccessfully = false;
                this.Error = response.GetFormattedErrorMessage();
            }
            else
            {
                this.IsCalledSuccessfully = false;
            }
        }
    }
}