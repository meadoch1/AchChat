using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{
    public interface IParticipant
    {
        string UserId { get; set; }
        DateTime Joined { get; set; }
        DateTime Left { get; set; }
        bool Active { get; set; }
    }
}
