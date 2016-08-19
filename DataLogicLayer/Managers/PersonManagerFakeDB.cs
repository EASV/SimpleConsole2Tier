using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Managers
{
    class PersonManagerFakeDb : IPersonManager
    {
        private static int Id = 1;
        
        List<Person> _persons = new List<Person>();

        public PersonManagerFakeDb()
        {
            AddPerson(new Person{Name = "Lars"});

            AddPerson(new Person{Name = "Ole"});
        }

        public List<Person> GetPersons()
        {
            return new List<Person>(_persons);
        }

        public Person AddPerson(Person p)
        {
            _persons.Add(p);
            p.Id = Id++;
            return p;
        }

        /*public void DeletePerson(int id)
        {
            persons.RemoveAll(x => x.Id == id);
        }*/

        /*public void UpdatePerson(Person person)
        {
            if (person == null) new NullReferenceException();

            var personInDb = persons.FirstOrDefault(x => x.Id == person.Id);

            if (personInDb != null) personInDb.Name = person.Name;
        }*/
    }
}
