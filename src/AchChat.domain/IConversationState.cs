using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{
    public interface IConversationState
    {
        DateTime TimeStamp { get; set; }
        ConversationStateType State { get; set; }
    }
}
