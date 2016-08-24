using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolDLL.Entities;
using MyCoolDLL.Managers;

namespace MyCoolDLL
{
    public class DllFacade
    {
        public IManager<Person> GetPersonManager()
        {
            return new PersonManager();
        }

        public IManager<Address> GetAddressManager()
        {
            return new AddressManager();
        }
    }
}
