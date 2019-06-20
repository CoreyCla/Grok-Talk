using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public class MessageRepository : IMessageRepo
    {
        //private  static List<Message> messageList = new List<Message>();
        private DataContext context;
        public MessageRepository(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Message> Messages
        {
            get
            {
                return context.Messages;
            }
        }

        public void AddMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public Message GetMessageById(long id)
        {
            Message message = context.Messages.First(m => m.Id == id);
            return message;
        }

        public int Count()
        {
            return Messages.Count();
        }
    }
}
