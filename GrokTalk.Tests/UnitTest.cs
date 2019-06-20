using System;
using GrokTalk.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using GrokTalk.Controllers;
using GrokTalk.Repositories;

namespace GrokTalk.Tests
{
    public class UnitTest : IDisposable
    {
        // Arrange
        MessageController messageController;
        ThreadController threadController;
        FakeThreadRepo fakeThreadRepo;
        FakeMessageRepo fakeMessageRepo;
        Message message;

        public UnitTest()
        {
            message = new Message()
            {
                From = "Corey Clark",
                Body = "Corey Clark message body.",
                Priority = true,
                Id = 1
            };

            fakeThreadRepo = new FakeThreadRepo();
            fakeMessageRepo = new FakeMessageRepo();

            messageController = new MessageController(fakeMessageRepo);
            threadController = new ThreadController(fakeThreadRepo);
        }

        public void Dispose()
        {
            messageController.Dispose();
            threadController.Dispose();
        }

        // Only had two methods in my contact controllers, so I added a test for the 
        // AddMessage method in the repository.
        [Fact]
        public void GetMessagebyIdTest()
        {
            // Act
            messageController.repository.AddMessage(message);
            Message firstMessage = messageController.repository.GetMessageById(1);
            Assert.Equal(1, firstMessage.Id);
        }

        [Fact]
        public void AddMessageTest()
        {            
            messageController.AddMessage("Cranberry", true, "High-pri message.");

            // Tests to see if the message was added by checking the end of the list 
            Assert.Equal("Cranberry", fakeMessageRepo.MessageList[fakeMessageRepo.MessageList.Count() - 1].From);
        }

        [Fact]
        public void AddThreadTest()
        {
            threadController.AddThread("This is subject.");

            // Tests to see if the thread was added by checking the end of the list 
            Assert.Equal("This is subject.", fakeThreadRepo.ThreadList[fakeThreadRepo.ThreadList.Count() - 1].Subject);
        }
    }
}
