using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public interface IMessageRepo
    {
        IEnumerable<Message> Messages { get; }
        void AddMessage(Message message);
        Message GetMessageById(long id);
        int Count();
    }
}
