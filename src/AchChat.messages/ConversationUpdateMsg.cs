using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AchChat.domain;

namespace AchChat.messages
{
    public class ConversationUpdateMsg
    {
        public Guid ConversationId { get; set; }
        public string FromUser { get; set; }
        public string Content { get; set; }
        public DateTime Sent { get; set; }
    }
}
