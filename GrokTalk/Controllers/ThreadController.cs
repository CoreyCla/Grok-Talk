using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrokTalk.Models;
using System.ComponentModel.DataAnnotations;

namespace GrokTalk.Controllers
{
    public class ThreadController : Controller
    {
        [Required]
        [Display(Name = "Threads")]
        private IThreadRepo repository; 

        public ThreadController(IThreadRepo repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            // Changes the title in the Index view to Thread List
            ViewData["Title"] = "Thread List";

            // Passes the number of threads in the database to the thread view
            ViewBag.threadCount = repository.Threads.Count();

            // Another way to do what the IOrderedEnumerable<Message> does in /Message/Index
            var threads = repository.Threads.OrderBy(date => date.ExecutionDate);
            return View(threads);
        }
        
        public IActionResult AddThread()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddThread(string subject)
        {
            Thread thread = new Thread();
            thread.Subject = subject;
            thread.ExecutionDate = DateTime.Now;
            repository.AddThread(thread);

            return RedirectToAction("Index");
        }
    }
}