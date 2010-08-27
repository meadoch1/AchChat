using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchChat.messages;
using Symbiote.Jackalope;
using Symbiote.Core.Extensions;
using AchChat.processor;

namespace AchChat.processor.MessageHandlers
{
    public class ConversationUpdateMsgHandler : MsgHandlerBase, IMessageHandler<ConversationUpdateMsg>
    {
        public ConversationUpdateMsgHandler(IBus bus, IConfigureEndpoints configureEndpoints)
            : base(bus, configureEndpoints)
        {
            
        }

        public void Process(ConversationUpdateMsg message, IMessageDelivery messageDelivery)
        {
            // update model

            // publish notifications to clients
            "Forwarding Message...{0}".ToDebug<AchChatProcessorService>(message.Sent);
            _bus.Send(_configureEndpoints.NotifyMsgExchange, message, string.Format(_configureEndpoints.NotifyMsgRouteFormat, message.ConversationId));

            // acknowledge msg
            messageDelivery.Acknowledge();
        }
    }
}
