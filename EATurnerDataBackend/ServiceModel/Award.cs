using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataBackend.ServiceModel
{
    public class Award
    {
        public int AwardId { get; set; }
        public int TitleId { get; set; }
        public bool AwardWon { get; set; }
        public string AwardName { get; set; }
        public DateTime AwardTime { get; set; }
        public string AwardCompany { get; set; }
    }
}