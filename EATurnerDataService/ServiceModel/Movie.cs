using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class Movie
    {
        public List<ServiceModel.Title> Titles { get; set; }
        public List<ServiceModel.Participant> Actors { get; set; }
        public List<ServiceModel.AwardData> Awards { get; set; }
        public List<ServiceModel.OtherName> OtherNames { get; set; }
        public List<ServiceModel.Genre> Genres { get; set; }
        public List<ServiceModel.StoryLine> StoryLines { get; set; }
        public List<ServiceModel.TitleGenre> TitleGenres {get; set;}
        public List<ServiceModel.TitleParticipant> TitleParticipants { get; set; }
    }
}