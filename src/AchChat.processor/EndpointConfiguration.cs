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
        private readonly string _processMsgExchange = ConfigurationManager.AppSettings["ProcessExchange"];
        public string ProcessMsgQueue { get { return ConfigurationManager.AppSettings["ProcessQueue"]; } }

        public string NotifyMsgExchange { get { return ConfigurationManager.AppSettings["NotifyExchange"]; } }
        public string RequestNotifyMsgExchange { get { return ConfigurationManager.AppSettings["RequestNotifyExchange"]; } }
        public string NotifyMsgRouteFormat { get { return ConfigurationManager.AppSettings["ConversationUpdateMsgNotifyRouteFormat"]; } }


        protected IBus bus { get; set; }

        public void Configure()
        {
            //bus.AddEndPoint(x => x.Exchange(_statusUpdateMsgExchange, ExchangeType.fanout).QueueName(_statusUpdateMsgRoute).Durable());
            //bus.DefineRouteFor<StatusUpdateMsg>(x => x.SendTo(_statusUpdateMsgRoute));

            //Incoming messages from clients to be processed
            "Binding {0} (Queue) to {1} (Exchange)".ToDebug<AchChatProcessorService>(ProcessMsgQueue, _processMsgExchange);
            bus.AddEndPoint(x => x.Exchange(_processMsgExchange, ExchangeType.fanout).QueueName(ProcessMsgQueue).Durable());

            //Outgoing notifications to clients
            "Creating Exchange Endpoint {0}".ToDebug<AchChatProcessorService>(NotifyMsgExchange);
            bus.AddEndPoint(x => x.Exchange(NotifyMsgExchange, ExchangeType.fanout).Durable());
            bus.DefineRouteFor<ConversationUpdateMsg>(x => x.SendTo(NotifyMsgExchange));


            //Outgoing notifications to clients
            "Creating Exchange Endpoint {0}".ToDebug<AchChatProcessorService>(RequestNotifyMsgExchange);
            bus.AddEndPoint(x => x.Exchange(RequestNotifyMsgExchange, ExchangeType.fanout).Durable());
            bus.DefineRouteFor<ConversationRequestMsg>(x => x.SendTo(RequestNotifyMsgExchange));

            
        }

        public EndpointConfiguration(IBus bus)
        {
            this.bus = bus;
        }
    }
}
