using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrokTalk.Models;
using GrokTalk.Repositories;

namespace GrokTalk.Repositories
{
    public class FakeThreadRepo : IThreadRepo
    {
        private List<Thread> threadList = new List<Thread>();
        public List<Thread> ThreadList { get { return threadList; } }

        // The tests were written after I had implemented database support, so the IMessageRepo
        // and MessageRepo classes have methods that are specific to sending data to the database.
        // The below block of code is used to negate the "Not Implemented" errors I received as a result
        // of testing old methods
        public IEnumerable<Thread> Threads => throw new NotImplementedException();

        public FakeThreadRepo()
        {
            AddTestData();
        }

        public void AddThread(Thread thread)
        {
            ThreadList.Add(thread);
        }

        public int Count()
        {
            return ThreadList.Count();
        }

        void AddTestData()
        {
            Thread thread1 = new Thread()
            {
                Subject = "This is a hardcoded subject from Nate.",
            };

            Thread thread2 = new Thread()
            {
                Subject = "This is a hardcoded subject from Josh.",
            };

            Thread thread13 = new Thread()
            {
                Subject = "This is a hardcoded subject from Betty.",
            };
        }
    }
}
