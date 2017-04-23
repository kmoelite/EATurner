using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class StoryLine
    {
        public int StoryLineId { get; set; }
        public int TitleId { get; set; }
        public string StoryLineType { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }

    }
}