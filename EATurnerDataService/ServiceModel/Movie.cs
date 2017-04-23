using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class Movie
    {
        public List<Title> Titles { get; set; }
        public List<Participant> Actors { get; set; }
        public List<Award> Awards { get; set; }
        public List<OtherName> OtherNames { get; set; }
        public List<Genre> Genres { get; set; }
        public List<StoryLine> StoryLines { get; set; }
        public List<TitleGenre> TitleGenres {get; set;}
        public List<TitleParticipant> TitleParticipants { get; set; }
    }
}