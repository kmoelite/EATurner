using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using EATurnerDataService.ServiceModel.ResponseDTOs;

namespace EATurnerDataService.ServiceModel.RequestDTOs
{
    [Route("/TitleService/searchDetail/{TitleId}", "POST")]

    public class DetailSearchRequest : IReturn<DetailSearchResponse>
    {
        public int TitleId { get; set; }
    }
}