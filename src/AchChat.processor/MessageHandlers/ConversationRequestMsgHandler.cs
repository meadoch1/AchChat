using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchChat.messages;
using Symbiote.Core.Extensions;
using Symbiote.Jackalope;
using AchChat.processor;

namespace AchChat.processor.MessageHandlers
{
    class ConversationRequestMsgHandler : MsgHandlerBase,  IMessageHandler<ConversationRequestMsg>
    {
        public ConversationRequestMsgHandler(IBus bus, IConfigureEndpoints configureEndpoints)
            : base(bus, configureEndpoints)
        {
            
        }

        public void Process(ConversationRequestMsg message, IMessageDelivery messageDelivery)
        {
            // update model

            // publish notifications to clients
            message.RoutingKey = string.Format(_configureEndpoints.NotifyMsgRouteFormat, message.ConversationId);
            "Creating new conversation...{0}".ToDebug<AchChatProcessorService>(message.Sent);
            _bus.Send(_configureEndpoints.RequestNotifyMsgExchange, message);

            // acknowledge msg
            messageDelivery.Acknowledge();

        }
    }
}
