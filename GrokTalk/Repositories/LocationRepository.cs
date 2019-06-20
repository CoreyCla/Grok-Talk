using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public class LocationRepository
    {
        private static List<Location> locationList = new List<Location>();
        public static List<Location> LocationList { get { return locationList; } }

        public static void AddLocation(Location location)
        {
            locationList.Add(location);
        }
    }
}
