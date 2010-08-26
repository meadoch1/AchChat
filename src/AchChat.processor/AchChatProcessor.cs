using System;
using Relax;
using Symbiote.Daemon;
using Symbiote.Jackalope;

namespace AchChat.processor
{
    public class AchChatProcessor : IDaemon
    {
        private IBus _bus;
        private IDocumentRepository _couch;

        public AchChatProcessor(IBus bus, IDocumentRepository couch)
        {
            _bus = bus;
            _couch = couch;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}