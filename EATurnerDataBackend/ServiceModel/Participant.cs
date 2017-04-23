using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EATurnerDataBackend.ServiceModel
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public string ParticipantType { get; set; }
    }
}