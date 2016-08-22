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
    
    public class Person : Entity
    {
        public delegate void PropertyChanged(string propName, object oldValue, object newValue);

        public event PropertyChanged Propchanged;

        private string _name;
        public string Name {
            get { return _name; }
            set
            {
                var oldValue = _name;
                _name = value;
                Propchanged?.Invoke("Name", oldValue, _name);
               /* if (Propchanged != null)
                {
                    Propchanged("Name", oldValue, _name);
                }*/
            } 
        }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return $"{Name} {Gender} - Born this year: {BirthDate.Year} - Email: {Email}";
        }
    }
}