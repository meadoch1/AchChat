using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace AchChat.domain.tests
{
    public class when_adding_chat_message : with_Conversation
    {
        private const string STR_TestMessage1 = "test message1";
        private const string STR_TestUser1 = "test user1";

        private Because of = () => conversation.AddMessage(STR_TestUser1, STR_TestMessage1);

        private It should_have_one_message_in_list = () => conversation.Content.Count.ShouldEqual(1);
        private It should_match_user_name = () => conversation.Content.First().FromUser.ShouldEqual(STR_TestUser1);
        private It should_match_message_text = () => conversation.Content.First().Text.ShouldEqual(STR_TestMessage1);


    }
}
