using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.messages
{
    public class ConversationRequestMsg
    {
        public Guid ConversationId { get; set; }
        public string FromUser { get; set; }
        public DateTime Sent { get; set; }
        public string RoutingKey { get; set; }
    }
}
