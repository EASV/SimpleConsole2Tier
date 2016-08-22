using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities;

namespace DataLogicLayer
{
    public abstract class AbstractPersonManager : IPersonManager
    {
        public delegate void PersonsUpdated(List<Person> persons);

        public event PersonsUpdated PersonsUpdatedEvent;

        public abstract List<Person> GetPersons();

        public Person AddPerson(Person p)
        {
            Person person = Add(p);
            PersonsUpdatedEvent?.Invoke(GetPersons());
            return person;
        }

        internal abstract Person Add(Person p);

        public abstract bool Delete(Person p);

        public abstract Person GetPerson(int id);

        public abstract Person UpdatePerson(Person person);
    }
}
