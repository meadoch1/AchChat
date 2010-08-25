using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchChat.domain
{
    public class Conversation
    {
        public virtual IList<IChatMessage> Content { get; set; }
        public virtual Guid ConversationId { get; set; }
        public virtual IList<Participant> Participants { get; set; }
        public virtual IList<IConversationState> StateHistory { get; set; }

        public virtual IConversationState CurrentState
        {
            get { return StateHistory.Last(); }
        }

        public virtual IParticipant Initiator
        {
            get
            {
                return Participants.First();
            }
        }

        /// <summary>
        /// Initializes a new instance of the Conversation class.
        /// </summary>
        public Conversation()
        {
            Init();
        }

        private void Init()
        {
            Participants = new List<Participant>();
            Content = new List<IChatMessage>();
            ConversationId = Guid.NewGuid();
            StateHistory = new List<IConversationState>();
        }

        public static Conversation CreateConversation()
        {
            return new Conversation();
        }

        public void AddMessage(string userId, string text)
        {
            Content.Add(new ChatMessage() { FromUser = userId, SentTime = DateTime.Now, Text = text });
        }

    }

}