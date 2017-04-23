using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using EATurnerDataBackend.ServiceModel.ResponseDTOs;

namespace EATurnerDataBackend.ServiceModel.RequestDTOs
{
    public class DetailSearchRequest : IReturn<DetailSearchResponse>
    {
        public int TitleId { get; set; }
    }
}