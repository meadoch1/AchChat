using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.messages
{
    public class StatusUpdateMsg
    {
        public string UserId { get; set; }
        public bool Active { get; set; }
    }
}
