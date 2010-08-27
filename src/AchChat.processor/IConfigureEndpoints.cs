using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Symbiote.Jackalope;

namespace AchChat.processor
{
    public interface IConfigureEndpoints
    {
        void Configure();
        string ProcessMsgQueue { get; }
        string NotifyMsgExchange { get; }
        string NotifyMsgRouteFormat { get; }
        string RequestNotifyMsgExchange { get; }
    }
}
