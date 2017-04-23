using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataService.ServiceModel
{
    public class TitleParticipant
    {
        public int TitleParticipantId { get; set; }
        public int TitleId { get; set; }
        public int ParticipantId { get; set; }
        public bool isKeyParticipant { get; set; }
        public string RoleType { get; set; }
        public bool isOnScreen { get; set; }
    }
}