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

        /// <summary>
        /// Delete the person
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool Delete(Person p);

        /// <summary>
        /// Gets a single person by finding his Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Person GetPerson(int id);

        /// <summary>
        /// Updates a person I like documenting stuff so funny..
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        Person UpdatePerson(Person person);
    }
}
