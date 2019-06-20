using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            DataContext context = app.ApplicationServices.GetRequiredService<DataContext>();
            context.Database.EnsureCreated();
            if (!context.Threads.Any())
            {
                Thread thread = new Thread();
                thread.Subject = "This is a hardcoded subject.";
                // This will eventually be a method that adds the unique message id to a list within the
                // thread so that it can be iterated on to fetch the thread specific messages from the 
                // repository and send them to a view.
                //thread.AddMessageId(threadMessage.Id);
                context.Threads.Add(thread);
                Thread thread2 = new Thread();

                thread.Subject = "This is another hardcoded subject.";
                context.Threads.Add(thread2);
                context.SaveChanges();
            }
            if (!context.Messages.Any())
            {
                Message regularMessage = new Message
                {
                    Subject = "This is a hardcoded subject from Ian.",
                    From = "Ian",
                    Body = "This is a hardcoded body from Ian.",
                    Priority = true
                };
                context.Messages.Add(regularMessage);

                Message regularMessage2 = new Message
                {
                    Subject = "This is a hardcoded subject from Rob.",
                    From = "Rob",
                    Body = "This is a hardcoded body from Rob.",
                    Priority = false
                };
                context.Messages.Add(regularMessage2);
                context.SaveChanges();
            }
        }
    }
}
