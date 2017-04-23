using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using System.Configuration;

namespace EATurnerDataService
{
    public static class ServiceStackClient
    {
        public static JsonServiceClient GetClient()
        {
            return new JsonServiceClient(ConfigurationManager.AppSettings["ApiUrl"]);
        }

        public static JsonServiceClient GetClient(string endpointUri)
        {
            return new JsonServiceClient(endpointUri);
        }
    }
}