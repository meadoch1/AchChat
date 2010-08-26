using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchChat.messages;
using Symbiote.Jackalope;

namespace AchChat.processor.MessageHandlers
{
    public class ConversationUpdateMsgHandler : IMessageHandler<ConversationUpdateMsg>
    {
        private IBus _bus;

        public ConversationUpdateMsgHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Process(ConversationUpdateMsg message, IMessageDelivery messageDelivery)
        {
            // update model

            // publish notifications to clients
            _bus.Send(message);

            // acknowledge msg
            messageDelivery.Acknowledge();
        }
    }
}
