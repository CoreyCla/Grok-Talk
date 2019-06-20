using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrokTalk.Models;

namespace GrokTalk.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            // Sorts list alphabetically by default.
            var location = LocationRepository.LocationList.OrderBy(title => title.Title);
            return View(location);
        }

        public LocationController()
        {
            if (LocationRepository.LocationList.Count == 0)
            {
                Location location = new Location()
                {
                    Title = "Lane Community College",
                    Address = "4000 E 30th Ave, Eugene, OR 97405",
                    About = "This is the gathering place of the current community."
                };
                LocationRepository.AddLocation(location);

                Location newLocation1 = new Location()
                {
                    Title = "Tiger's Den",
                    Address = "6552 W Someplace Ave, Eugene, OR 97401",
                    About = "This is an imaginary bar for our favorite community members."
                };
                LocationRepository.AddLocation(newLocation1);

                Location newLocation2 = new Location()
                {
                    Title = "Wandering Goat",
                    Address = "3717 E Somewhere Ave, Eugene, OR 97405",
                    About = "This is the urban watering hole."
                };
                LocationRepository.AddLocation(newLocation2);
            }
        }
    }
}