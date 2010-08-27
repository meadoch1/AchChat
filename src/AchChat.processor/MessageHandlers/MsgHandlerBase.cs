using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Symbiote.Jackalope;

namespace AchChat.processor.MessageHandlers
{
    public abstract class MsgHandlerBase
    {

        protected IBus _bus;
        protected IConfigureEndpoints _configureEndpoints;

        public MsgHandlerBase(IBus bus, IConfigureEndpoints configureEndpoints)
        {
            Init(bus, configureEndpoints);
        }
        private void Init(IBus bus, IConfigureEndpoints configureEndpoints)
        {
            _bus = bus;
            _configureEndpoints = configureEndpoints;
        }

    }
}
