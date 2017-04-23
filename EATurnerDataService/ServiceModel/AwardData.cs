using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class AwardData
    {
        public int AwardId { get; set; }
        public int TitleId { get; set; }
        public bool AwardWon { get; set; }
        public string Award { get; set; }
        public int AwardYear { get; set; }
        public string AwardCompany { get; set; }
    }
}