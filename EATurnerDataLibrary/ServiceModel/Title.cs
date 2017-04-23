using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int TitleTypeId { get; set; }
        public DateTime ReleaseYear { get; set; }
        public DateTime ProcessedDateTimeUTC { get; set; }
    }
}