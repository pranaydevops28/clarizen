﻿namespace Ekin.Clarizen.Data
{
    public class CreateDiscussion : Call<Result.CreateDiscussion>
    {
        public CreateDiscussion(Request.CreateDiscussion request, CallSettings callSettings)
        {
            _request = request;
            _callSettings = callSettings;
            _url = (callSettings.IsBulk ? string.Empty : callSettings.ServerLocation) + "/data/createDiscussion";
            _method = System.Net.Http.HttpMethod.Post;
        }
     }
}