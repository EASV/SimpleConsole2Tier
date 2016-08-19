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
        
        List<Person> persons = new List<Person>();

        public PersonManagerFakeDb()
        {
            AddPerson(new Person{Name = "Lars"});

            AddPerson(new Person{Name = "Ole"});
        }

        public List<Person> GetPersons()
        {
            return new List<Person>(persons);
        }

        public Person AddPerson(Person p)
        {
            persons.Add(p);
            p.Id = Id++;
            return p;
        }

        public bool Delete(Person p)
        {
            /*foreach (var person in persons)
            {
                if (person.Id == p.Id)
                {
                    persons.Remove(person);

                }

            }*/



            persons.RemoveAll(person => person.Id == p.Id);


            return persons.FirstOrDefault(person => person.Id == p.Id) == null;
        }

        public Person GetPerson(int id)
        {
            /*foreach (var person in persons)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }*/
            //return null;
            return persons.FirstOrDefault(person => person.Id == id);
        }

        public Person UpdatePerson(Person p)
        {
            var personFound = persons.FirstOrDefault(person => person.Id == p.Id);
            personFound.Name = p.Name;
            return personFound;
        }


        /*public Person UpdatePerson(Person person)
        {
            if (person == null) new NullReferenceException();

            var personInDb = persons.FirstOrDefault(x => x.Id == person.Id);

            if (personInDb != null) personInDb.Name = person.Name;

            return person;
        }*/
    }
}
