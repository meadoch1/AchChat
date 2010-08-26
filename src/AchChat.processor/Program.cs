using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using AchChat.domain;
using Relax;
using Symbiote.Core;
using Symbiote.Daemon;
using Symbiote.Jackalope;
using Symbiote.StructureMap;

namespace AchChat.processor
{
    class Program
    {
        private static string _rabbitServer = ConfigurationManager.AppSettings["RabbitServer"];
        private static string _couchServer = ConfigurationManager.AppSettings["CouchServer"];
        private static string _couchDbName= ConfigurationManager.AppSettings["CouchDatabase"];

        static void Main(string[] args)
        {
            Assimilate
                .Core<StructureMapAdapter>()
                .Jackalope(x =>
                    x.AddServer(s =>
                        s.Address(_rabbitServer)
                         .AMQP08()))
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
