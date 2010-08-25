using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace AchChat.domain.tests
{
    public abstract class with_Conversation
    {
        protected static Conversation conversation;

        private Establish context = () =>  conversation = Conversation.CreateConversation();

    }
}