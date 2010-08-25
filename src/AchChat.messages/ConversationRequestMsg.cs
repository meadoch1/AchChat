using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.messages
{
    public class ConversationRequestMsg
    {
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
        public Guid ConversationId { get; set; }
    }
}
