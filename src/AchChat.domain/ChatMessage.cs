using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{
    public class ChatMessage : IChatMessage
    {
        public virtual string Text { get; set; }
        public virtual string FromUser { get; set; }
        public virtual DateTime SentTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the Message class.
        /// </summary>
        public ChatMessage()
        {
            Init();
        }

        private void Init()
        {
            SentTime = DateTime.Now;
        }
    }
}