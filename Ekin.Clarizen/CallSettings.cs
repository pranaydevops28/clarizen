﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekin.Clarizen
{
    public class CallSettings
    {
        public string serverLocation { get; set; }
        public string sessionId { get; set; }
        public int? timeout { get; set; } = null;
        public bool isBulk { get; set; } = false;
        public bool serializeNullValues { get; set; } = false;

        public CallSettings()
        {

        }

        public static CallSettings GetFromAPI(API api, int? timeout = null)
        {
            if (api != null)
            {
                return new CallSettings()
                {
                    serverLocation = api.serverLocation,
                    sessionId = api.sessionId,
                    isBulk = api.isBulk,
                    serializeNullValues = api.serializeNullValues,
                    timeout = (timeout != null) ? timeout : api.timeout
                };
            }
            else
            {
                return new CallSettings();
            }
        }
    }
}