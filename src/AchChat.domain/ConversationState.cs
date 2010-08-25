using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{

    public enum ConversationStateType
    {
        Requested,
        Active,
        Done,
        Abandoned
    }
    public class ConversationState : IConversationState
    {
        public DateTime TimeStamp { get; set; }
        public ConversationStateType State { get; set; }


        
    }
}

