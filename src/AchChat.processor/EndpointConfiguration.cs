using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Symbiote.Core.Extensions;
using Symbiote.Jackalope;

using AchChat.messages;
namespace AchChat.processor
{
    public class EndpointConfiguration : IConfigureEndpoints
    {

 //       private static string _statusUpdateMsgRoute = ConfigurationManager.AppSettings["StatusUpdateMsgRoute"];
 //       private static string _statusUpdateMsgExchange = ConfigurationManager.AppSettings["StatusUpdateMsgExchange"];
 //
        private readonly string _conversationUpdateMsgProcessExchange = ConfigurationManager.AppSettings["ProcessExchange"];
        public string ConversationUpdateMsgProcessQueue { get { return ConfigurationManager.AppSettings["ProcessQueue"]; } }

        private static readonly string _conversationUpdateMsgNofifyExchange = ConfigurationManager.AppSettings["NotifyExchange"];
 //       private static string _conversationUpdateMsgNotifyRouteFormat = ConfigurationManager.AppSettings["ConversationUpdateMsgNotifyRouteFormat"];


        protected IBus bus { get; set; }

        public void Configure()
        {
            //bus.AddEndPoint(x => x.Exchange(_statusUpdateMsgExchange, ExchangeType.fanout).QueueName(_statusUpdateMsgRoute).Durable());
            //bus.DefineRouteFor<StatusUpdateMsg>(x => x.SendTo(_statusUpdateMsgRoute));

            //Incoming messages from clients to be processed
            "Binding {0} (Queue) to {1} (Exchange)".ToDebug<AchChatProcessorService>(ConversationUpdateMsgProcessQueue, _conversationUpdateMsgProcessExchange);
            bus.AddEndPoint(x => x.Exchange(_conversationUpdateMsgProcessExchange, ExchangeType.fanout).QueueName(ConversationUpdateMsgProcessQueue).Durable());

            //Outgoing notifications to clients
            "Creating Exchange Endpoint {0}".ToDebug<AchChatProcessorService>(_conversationUpdateMsgNofifyExchange);
            bus.AddEndPoint(x => x.Exchange(_conversationUpdateMsgNofifyExchange, ExchangeType.fanout).Durable());
            bus.DefineRouteFor<ConversationUpdateMsg>(x => x.SendTo(_conversationUpdateMsgNofifyExchange));
        }

        public EndpointConfiguration(IBus bus)
        {
            this.bus = bus;
        }
    }
}
