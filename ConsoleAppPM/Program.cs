using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolDLL;
using MyCoolDLL.Entities;

namespace ConsoleAppPM
{
    class Program
    {
        private static IManager<Person> personsManager = 
            new DllFacade().GetPersonManager();
        static void Main(string[] args)
        {
            //personsManager.Create(new Person()
            //{
            //    Name = "John",
            //    Email = "john@myaddress.com",
            //    BirthDate = DateTime.Now.AddYears(-20)

            //});
            //personsManager.Create(new Person()
            //{
            //    Name = "Bill",
            //    Email = "bill@myaddress.com",
            //    BirthDate = DateTime.Now.AddYears(-25)

            //});
            
            var persons = personsManager.ReadAll();
            persons.ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
