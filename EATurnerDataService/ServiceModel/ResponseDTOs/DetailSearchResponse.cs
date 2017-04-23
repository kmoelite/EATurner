using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel.ResponseDTOs
{
    public class DetailSearchResponse
    {
        public Movie Movie {get; set;}
        public string Error { get; set; }
    }
}