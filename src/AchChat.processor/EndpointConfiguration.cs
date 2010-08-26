using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Symbiote.Jackalope;

using AchChat.messages;
namespace AchChat.processor
{
    class EndpointConfiguration : IConfigureEndpoints
    {

 //       private static string _statusUpdateMsgRoute = ConfigurationManager.AppSettings["StatusUpdateMsgRoute"];
 //       private static string _statusUpdateMsgExchange = ConfigurationManager.AppSettings["StatusUpdateMsgExchange"];
 //
        private static readonly string _conversationUpdateMsgProcessExchange = ConfigurationManager.AppSettings["ProcessExchange"];
        public static readonly string ConversationUpdateMsgProcessQueue = ConfigurationManager.AppSettings["ProcessQueue"];

        private static readonly string _conversationUpdateMsgNofifyExchange = ConfigurationManager.AppSettings["NotifyExchange"];
 //       private static string _conversationUpdateMsgNotifyRouteFormat = ConfigurationManager.AppSettings["ConversationUpdateMsgNotifyRouteFormat"];


        protected IBus bus { get; set; }

        public void Configure()
        {
            //bus.AddEndPoint(x => x.Exchange(_statusUpdateMsgExchange, ExchangeType.fanout).QueueName(_statusUpdateMsgRoute).Durable());
            //bus.DefineRouteFor<StatusUpdateMsg>(x => x.SendTo(_statusUpdateMsgRoute));

            //Incoming messages from clients to be processed
            bus.AddEndPoint(x => x.Exchange(_conversationUpdateMsgProcessExchange, ExchangeType.fanout).QueueName(_conversationUpdateMsgProcessQueue).Durable());
            
            //Outgoing notifications to clients
            bus.AddEndPoint(x => x.Exchange(_conversationUpdateMsgNofifyExchange, ExchangeType.fanout).QueueName(_conversationUpdateMsgNotifyQueue).Durable());
            bus.DefineRouteFor<ConversationUpdateMsg>(x => x.SendTo(_conversationUpdateMsgNofifyExchange));
        }

        public EndpointConfiguration(IBus bus)
        {
            this.bus = bus;
        }
    }
}
