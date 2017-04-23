using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class TitleGenre
    {
        public int TitleGenreId { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }
    }
}