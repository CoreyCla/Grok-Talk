using GrokTalk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using GrokTalk.Repositories;
using System.Threading.Tasks;

namespace GrokTalk.Repositories
{
    public class FakeMessageRepo : IMessageRepo
    {
        private List<Message> messageList = new List<Message>();
        public List<Message> MessageList { get { return messageList; } }

        // The tests were written after I had implemented database support, so the IMessageRepo
        // and MessageRepo classes have methods that are specific to sending data to the database.
        // The below block of code is used to negate the "Not Implemented" errors I received as a result
        // of testing old methods
        public IEnumerable<Message> Messages => throw new NotImplementedException();

        public FakeMessageRepo()
        {
            AddTestData();
        }

        public void AddMessage(Message message)
        {
            MessageList.Add(message);
        }

        public int Count()
        {
            return MessageList.Count();
        }

        public Message GetMessageById(long id)
        {
            Message message = messageList.First(m => m.Id == id);
            return message;
        }

        void AddTestData()
        {
            Message message1 = new Message()
            {
                Subject = "This is a hardcoded subject from Nate.",
                From = "Nate",
                Body = "This is a hardcoded body from Nate.",
                Priority = true
            };

            Message message2 = new Message()
            {
                Subject = "This is a hardcoded subject from Josh.",
                From = "Josh",
                Body = "This is a hardcoded body from Josh.",
                Priority = true
            };

            Message message3 = new Message()
            {
                Subject = "This is a hardcoded subject from Betty.",
                From = "Betty",
                Body = "This is a hardcoded body from Betty.",
                Priority = true
            };
        }
    }
}
