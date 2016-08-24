using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Entities
{
    [Serializable]
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public int ZipCode { get; set; }
    }
}
