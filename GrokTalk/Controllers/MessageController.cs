using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrokTalk.Models;
using System.ComponentModel.DataAnnotations;

namespace GrokTalk.Controllers
{
    public class MessageController : Controller
    {
        [Required]
        [Display(Name = "Messages")]
        public IMessageRepo repository;

        public MessageController(IMessageRepo repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            // Changes the title in the Index view to Thread Messages
            ViewData["Title"] = "Thread Messages";

            // Passes the number of high priority messages in the database to the view. Later
            // on this will pass the number of high priority messages in a specific thread to
            // a layout or just the viewbag variable.
            ViewBag.PriorityCount = 0;
            for (int i = 0; i < repository.Count(); i++)
            {
                List<Message> messageList = repository.Messages.ToList();
                if (messageList[i].Priority == true)
                {
                    ViewBag.PriorityCount++;
                }
            }

            // Returns a list of message items, ordered by date, to the view
            var messages = repository.Messages.OrderBy(date => date.ExecutionDate);
            return View(messages);
        }

        public IActionResult AddMessage()
        {
            return View(); 
        }
        
        [HttpPost]
        public RedirectToActionResult AddMessage(string from, bool priority, string body)
        {
            if (ModelState.IsValid)
            {
                Message message = new Message();
                message.ExecutionDate = DateTime.Now;
                message.From = from;
                message.Priority = priority;
                message.Body = body;

                repository.AddMessage(message);

                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
