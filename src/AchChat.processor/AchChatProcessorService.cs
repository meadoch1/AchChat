using System;
using Relax;
using Symbiote.Core.Extensions;
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
            "ACH Chat Processor Starting Up...".ToDebug<AchChatProcessorService>();
            _bus.Subscribe(_endpointConfig.ProcessMsgQueue);
        }

        public void Stop()
        {
           
        }

         
    }
}