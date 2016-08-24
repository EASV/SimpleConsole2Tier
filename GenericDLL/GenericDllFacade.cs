using GenericDLL.Entities;
using GenericDLL.Managers;

namespace GenericDLL
{
    public class GenericDllFacade
    {
        public IManager<Person> GetPersonManager()
        {
            /*Person:
            Id
            Email
            BirthDate
            Name
            Address

            Address:
            Id
            Street
            City
            Zip
            Number*/
            



            return new PersonManagerFakeDb();
        }
    }
}
