using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities;
using DataLogicLayer.Managers;

namespace DataLogicLayer
{
    
    public class DLLFacade
    {
        
        public IPersonManager GetPersonManager()
        {
            return new PersonManagerLocalFile();
            //return new PersonManagerFakeDb();
            //return new ProxyPersonManager();
        }
        
    }
}
