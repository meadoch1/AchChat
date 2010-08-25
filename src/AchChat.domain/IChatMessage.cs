using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{
    public interface IChatMessage
    {
        string Text { get; set; }
        string FromUser { get; set; }
        DateTime SentTime { get; set; }
    }
}
