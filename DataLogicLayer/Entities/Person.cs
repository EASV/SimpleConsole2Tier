using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Entities
{
    public enum Gender
    {
        Male,
        Female,
        TheOthers
    }
    
    public class Person
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return $"{Name} {Gender} - Born this year: {BirthDate.Year} - Email: {Email}";
        }
    }
}