using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Managers;

namespace DataLogicLayer
{
    public class DLLFacade
    {
        public IPersonManager GetPersonManager()
        {
            //return new PersonManagerFakeDB();
            return new ProxyPersonManager();
        }
    }
}
