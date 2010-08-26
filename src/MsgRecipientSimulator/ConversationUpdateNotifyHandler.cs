using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchChat.messages;
using Symbiote.Core.Extensions;
using Symbiote.Jackalope;

namespace MsgRecipientSimulator
{
    public class ConversationUpdateNotifyHandler : IMessageHandler<ConversationUpdateMsg>
    {
        public void Process(ConversationUpdateMsg message, IMessageDelivery messageDelivery)
        {
            "Received a message from {0} that says \"{1}\" generated at {2}".ToDebug<ChatRecipientSimulatorService>(message.FromUser,
                                                                                                message.Content, message.Sent);
            messageDelivery.Acknowledge();
        }
    }
}
