using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Managers
{
    class PersonManagerFakeDb : AbstractPersonManager
    {
        private static int Id = 1;
        
        List<Person> persons = new List<Person>();
       
        public PersonManagerFakeDb()
        {
            Add(new Person{Name = "Lars", Email = "larsb@namnam.dk", Gender = Gender.Male });

            Add(new Person{Name = "Ole", Email = "ILoveBigBirds@zoo.com", Gender = Gender.Male });

            Add(new Person { Name = "Gurli", Email = "BoomBoomBOOM@letMeHearUSayAOOO.com", Gender = Gender.Female});
        }

        override
        public List<Person> GetPersons()
        {
            return new List<Person>(persons);
        }

        sealed override
        internal Person Add(Person p)
        {
            persons.Add(p);
            p.Id = Id++;
            return p;
        }

        override
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

        override
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

        override
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
