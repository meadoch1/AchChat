﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Symbiote.Core;
using Symbiote.Core.Extensions;
using Symbiote.Daemon;
using Symbiote.Jackalope;
using Symbiote.Log4Net;
using Symbiote.StructureMap;

namespace MsgRecipientSimulator
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
                   .AddConsoleLogger<ChatRecipientSimulatorService>(x => x.MessageLayout(m => m.Date().Message()))
                   .Daemon(x =>
                       x.Arguments(args)
                       .Description("Acts as a recipient of the Chat Processor's notifications.")
                       .DisplayName("AchFakeRecipient")
                       .Name("AchFakeRecipient"))
                   .RunDaemon()
                   ;
        }
    }

    public class ChatRecipientSimulatorService : IDaemon
    {

        private IBus _bus;

        public ChatRecipientSimulatorService(IBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            _bus.AddEndPoint(x => x.Exchange("ChatProcess", ExchangeType.fanout).QueueName("ChatRecipientSimulator"));
            "Listening for teh messagez".ToDebug<ChatRecipientSimulatorService>();
        }

        public void Stop()
        {
            
        }
    }
}