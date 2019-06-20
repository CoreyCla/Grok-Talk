using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrokTalk.Models
{
    public class PersonRepository
    {
        private static List<Person> personList = new List<Person>();
        public static List<Person> PersonList { get { return personList; } }

        public static void AddPerson(Person person)
        {
            personList.Add(person);
        }
    }
}
