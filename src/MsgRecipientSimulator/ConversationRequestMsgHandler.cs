using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchChat.messages;
using Symbiote.Core.Extensions;
using Symbiote.Jackalope;

namespace MsgRecipientSimulator
{
    class ConversationRequestMsgHandler : IMessageHandler<ConversationRequestMsg>
    {
        protected IBus _bus;

        public ConversationRequestMsgHandler(IBus bus)
        {
            Init(bus);
        }
        private void Init(IBus bus)
        {
            _bus = bus;
        }
        public void Process(ConversationRequestMsg message, IMessageDelivery messageDelivery)
        {
            _bus.BindQueue("ChatRecipientSimulator", "NotifyExchange", message.RoutingKey);
            "Listening for messagez on {0}".ToDebug<ChatRecipientSimulatorService>(message.RoutingKey);

            messageDelivery.Acknowledge();
        }
    }
}
