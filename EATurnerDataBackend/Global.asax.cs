using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using ServiceStack;
using Funq;
using EATurnerDataBackend.ServiceModel.RequestDTOs;

namespace EATurnerDataBackend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public class TitleSearchAppHost: AppHostBase
        {
            public TitleSearchAppHost() : base("Title Service", typeof(Services.TitleService).Assembly) { }
            public override void Configure(Container container)
            {
                Routes.Add<MovieSearchRequest>("/TitleService/search/{SearchText}").Add<DetailSearchRequest>("/TitleService/searchDetail/{TitleId}");
            }
        }

        protected void Application_Start()
        {
            (new TitleSearchAppHost()).Init();

        }
    }
}
