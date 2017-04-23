using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using EATurnerDataService.ServiceModel.ResponseDTOs;

namespace EATurnerDataService.ServiceModel.RequestDTOs
{
    [Route("/TitleService/search/{SearchText}", "POST")]
    public class MovieSearchRequest : IReturn<MovieSearchResponse>
    {
        public string SearchText { get; set; }
    }
}