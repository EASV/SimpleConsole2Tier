
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer;
using SpamEntities;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonManager manager = new DLLFacade().GetPersonManager();
            foreach (var person in manager.GetPersons())
            {
                Console.WriteLine(person);
            }

            manager.AddPerson(new Person()
            {
                Name = "Kurt"
            });
            

            foreach (var person in manager.GetPersons())
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }
}
