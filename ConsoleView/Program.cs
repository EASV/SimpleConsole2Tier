
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer;
using DataLogicLayer.Entities;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonManager manager = new DLLFacade().GetPersonManager();
            var persons = manager.GetPersons();
            
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
            
            manager.AddPerson(new Person()
            {
                Name = "Kurt"
            });
            
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }
}
