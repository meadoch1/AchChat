using System;
using System.Threading;
using AchChat.messages;
using Symbiote.Core.Extensions;
using Symbiote.Daemon;
using Symbiote.Jackalope;

namespace DummyMessageGenerator
{
    public class DummyMessageGeneratorService : IDaemon
    {
        private IBus _bus;

        public DummyMessageGeneratorService(IBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            _bus.AddEndPoint(x => x.Exchange("ChatProcess", ExchangeType.fanout).Durable());

            for(int i = 5; i >= 0; i-- )
            {
                for(int x = 0; x <= 5; x++)
                {
                    "Sending Message...".ToDebug<DummyMessageGeneratorService>();
                    _bus.Send("ChatProcess", new ConversationUpdateMsg() { Content = x.ToString(), FromUser = i.ToString(), Sent = DateTime.Now });
                    Thread.Sleep(i * 1000);
                }
            }
        }

        public void Stop()
        {
            
        }
    }
}