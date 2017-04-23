using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataBackend.ServiceModel.ResponseDTOs
{
    public class MovieSearchResponse
    {
        public Movie Movie {get; set;}
        public string Error { get; set; }
    }
}