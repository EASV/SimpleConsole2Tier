
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

            /*var aPm = manager as AbstractPersonManager;
            if (aPm != null) aPm.PersonsUpdatedEvent += WeUpdated;
            */

            var kurt = manager.AddPerson(new Person()
            {
                Name = "Gina",
                Gender = Gender.Female
            });
            
            //kurt.Propchanged += Propchange;
            
            kurt.Name = "Johnny";
            manager.UpdatePerson(kurt);
            
            DisplayPeople("Ladies:", manager.GetPersons(), IsFemale);
            DisplayPeople("Gents:", manager.GetPersons(), IsMale);

            Console.ReadLine();
        }

       

        /// <summary>
        /// A method to filter out the people you need
        /// </summary>
        /// <param name="people">A list of people</param>
        /// <param name="filter">A filter</param>
        /// <returns>A filtered list</returns>
        public delegate bool FilterDelegate(Person p);
        static void DisplayPeople(string title, 
            List<Person> people, 
            FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine($"{p.Name}, is a {p.Gender}");
                }
            }

            Console.Write("\n\n");
        }

        //==========FILTERS===================
        static bool IsFemale(Person p)
        {
            return p.Gender == Gender.Female;
        }

        static bool IsMale(Person p)
        {
            return p.Gender == Gender.Male;
        }

        private static void WeUpdated(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"person in updated List: {person}");
            }
        }

        private static void Propchange(string propname, object oldvalue, object newvalue)
        {
            
            Console.WriteLine($"propname : {propname}");
            Console.WriteLine($"oldvalue : {oldvalue}");
            Console.WriteLine($"newvalue : {newvalue}");
        }


        
    }
}
