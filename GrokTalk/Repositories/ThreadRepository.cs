using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public class ThreadRepository : IThreadRepo
    {
        //private static List<Thread> threadList = new List<Thread>();
        private DataContext context;
        public ThreadRepository(DataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Thread> Threads
        {
            get
            {
                return context.Threads;
            }
        }

        public void AddThread(Thread thread)
        {
            context.Threads.Add(thread);
            context.SaveChanges();
        }

        public Thread GetThreadById(long id)
        {
            Thread thread = context.Threads.First(t => t.Id == id);
            return thread;
        }

        public int Count()
        {
            return Threads.Count();
        }
    }
}
