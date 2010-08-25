using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{
    public class Participant : IParticipant
    {
        public string UserId { get; set; }
        public DateTime Joined { get; set; }
        public DateTime Left { get; set; }
        public bool Active { get; set; }
    }
}
