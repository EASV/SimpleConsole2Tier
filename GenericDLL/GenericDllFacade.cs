using GenericDLL.Entities;
using GenericDLL.Managers;

namespace GenericDLL
{
    public class GenericDllFacade
    {
        public IManager<Person> GetPersonManager()
        {
            return new PersonManagerFakeDb();
        }
    }
}
