using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataBackend.ServiceModel
{
    public class OtherName
    {
        public int OtherNameId { get; set; }
        public int TitleId { get; set; }
        public string TitleNameLanguage { get; set; }
        public string TitleNameType { get; set; }
        public string TableNameSortable { get; set; }
        public string TitleName { get; set; }

    }
}