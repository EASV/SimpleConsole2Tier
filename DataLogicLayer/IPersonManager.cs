using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities;

namespace DataLogicLayer
{
    public interface IPersonManager
    {
        /// <summary>
        /// Returns a list with all available
        /// Persons
        /// </summary>
        /// <returns>List</returns>
        List<Person> GetPersons();

        /// <summary>
        /// Create a person using the incoming
        /// Person
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Person</returns>
        Person AddPerson(Person p);
    }
}
