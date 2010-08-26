using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using AchChat.domain;
using Relax;
using Symbiote.Core;
using Symbiote.Daemon;
using Symbiote.Eidetic;
using Symbiote.Jackalope;
using Symbiote.Log4Net;
using Symbiote.StructureMap;

namespace AchChat.processor
{
    class Program
    {
        private static string _rabbitServer = ConfigurationManager.AppSettings["RabbitServer"];
        private static string _couchServer = ConfigurationManager.AppSettings["CouchServer"];
        private static string _couchDbName= ConfigurationManager.AppSettings["CouchDatabase"];
        private static string _memcacheServer= ConfigurationManager.AppSettings["MemcacheServer"];
        private static int _memcachePort= Convert.ToInt32(ConfigurationManager.AppSettings["MemcachePort"]);

        static void Main(string[] args)
        {
            Assimilate
                .Core<StructureMapAdapter>()
                .Jackalope(x =>
                    x.AddServer(s =>
                        s.Address(_rabbitServer)
                         .AMQP08()))
                .AddConsoleLogger<AchChatProcessorService>(x => x.MessageLayout(m => m.Date().Message().Newline()))
                .Dependencies(x => x.For<IConfigureEndpoints>().Use<EndpointConfiguration>())
                .Eidetic(x => x.AddServer(_memcacheServer, _memcachePort))
                .Relax(x => x.Server(_couchServer).AssignDatabaseToType<Conversation>(_couchDbName).Cache(TimeSpan.FromHours(0.5)))
                .Daemon(x =>
                    x.Arguments(args)
                    .Description("Processes chat messages for ACH chat.")
                    .DisplayName("AchChatProcessor")
                    .Name("AchChatProcessor"))
                .RunDaemon()
                ;
        }
    }
}
