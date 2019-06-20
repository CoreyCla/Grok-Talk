using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public interface IThreadRepo
    {
        IEnumerable<Thread> Threads { get; }
        void AddThread(Thread thread);
        int Count();
    }
}
