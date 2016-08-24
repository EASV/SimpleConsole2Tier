using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolDLL.Entities
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Id: {Id}";
        }
    }
}
