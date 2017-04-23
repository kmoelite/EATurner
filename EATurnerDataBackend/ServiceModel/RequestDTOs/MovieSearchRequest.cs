using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using EATurnerDataBackend.ServiceModel.ResponseDTOs;

namespace EATurnerDataBackend.ServiceModel.RequestDTOs
{
    public class MovieSearchRequest : IReturn<MovieSearchResponse>
    {
        public string SearchText { get; set; }
    }
}