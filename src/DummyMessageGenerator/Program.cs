using System.Collections.Generic;
using System.Linq;
using System.Text;
using Symbiote.Core;
using Symbiote.Daemon;
using Symbiote.Jackalope;
using Symbiote.Log4Net;
using Symbiote.StructureMap;

namespace DummyMessageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Assimilate
                   .Core<StructureMapAdapter>()
                   .Jackalope(x =>
                       x.AddServer(s =>
                           s.Address("localhost")
                            .AMQP08()))
                   .AddConsoleLogger<DummyMessageGeneratorService>(x => x.MessageLayout(m => m.Date().Message().Newline()))
                   .Daemon(x =>
                       x.Arguments(args)
                       .Description("Generates fake messages for testing...")
                       .DisplayName("AchFakeMsgGenerator")
                       .Name("AchFakeMsgGenerator"))
                   .RunDaemon()
                   ;
        }
    }
}
