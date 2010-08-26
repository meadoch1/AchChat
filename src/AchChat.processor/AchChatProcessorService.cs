using System;
using Relax;
using Symbiote.Daemon;
using Symbiote.Jackalope;

namespace AchChat.processor
{
    public class AchChatProcessorService : IDaemon
    {
        private IBus _bus;
        private IDocumentRepository _couch;
        private IConfigureEndpoints _endpointConfig { get; set; }

        public AchChatProcessorService(IBus bus, IDocumentRepository couch, IConfigureEndpoints endpointConfig)
        {
            _bus = bus;
            _couch = couch;
            _endpointConfig = endpointConfig;
            _endpointConfig.Configure();
        }

        public void Start()
        {
            _bus.Subscribe(_endpointConfig.ConversationUpdateMsgProcessQueue);
        }

        public void Stop()
        {
           
        }

         
    }
}