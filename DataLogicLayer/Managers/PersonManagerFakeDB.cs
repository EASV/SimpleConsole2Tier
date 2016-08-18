using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpamEntities;

namespace DataLogicLayer.Managers
{
    class PersonManagerFakeDB : IPersonManager
    {
        private static int Id = 1;
        
        List<Person> persons = new List<Person>();

        public PersonManagerFakeDB()
        {
            AddPerson(new Person(){Name = "Lars"});

            AddPerson(new Person(){Name = "Ole"});
        }

        public List<Person> GetPersons()
        {
            return persons;
        }

        public Person AddPerson(Person p)
        {
            persons.Add(p);
            p.Id = Id++;
            return p;
        }
    }
}
