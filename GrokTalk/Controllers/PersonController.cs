using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrokTalk.Models;

namespace GrokTalk.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            // Sorts list alphabetically by default.
            var people = PersonRepository.PersonList.OrderBy(name => name.Name);
            return View(people);
        }

        public PersonController()
        {
            if (PersonRepository.PersonList.Count == 0)
            {
                Person admin = new Person()
                {
                    Name = "Corey Clark",
                    Position = "Admin",
                    About = "This is something interesting about me."
                };
                PersonRepository.AddPerson(admin);

                Person newPerson1 = new Person()
                {
                    Name = "Betty Lou",
                    Position = "Dev Grunt",
                    About = "I also just work here."
                };
                PersonRepository.AddPerson(newPerson1);

                Person newPerson2 = new Person()
                {
                    Name = "Addy Ministrader",
                    Position = "Admin",
                    About = "I just work here."
                };
                PersonRepository.AddPerson(newPerson2);

            }
        }
    }
}