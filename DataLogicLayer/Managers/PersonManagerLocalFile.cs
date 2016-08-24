using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities;
using Newtonsoft.Json;

namespace DataLogicLayer.Managers
{


    class PersonManagerLocalFile : AbstractPersonManager
    {
        
        private readonly string _filePath = AppDomain.CurrentDomain.BaseDirectory + "persons.dat";
        public PersonManagerLocalFile()
        {
            if (!File.Exists(_filePath))
            {
                // Create a file to write to.
                File.WriteAllText(_filePath, "");
            }
        }

        override
        public List<Person> GetPersons()
        {
            var persons = LoadData();
            return persons;
         
        }


        sealed override
        internal Person Add(Person p)
        {

            var persons = GetPersons();
            var biggestPersonId = persons.OrderByDescending(u => u.Id).FirstOrDefault();
            if (biggestPersonId != null) p.Id = ++biggestPersonId.Id;
            persons.Add(p);

            SaveData(persons);

            return p;
        }
        
        override
        public bool Delete(Person p)
        {
            var persons = GetPersons();
            persons.RemoveAll(person => person.Id == p.Id);

            SaveData(persons);

            return persons.FirstOrDefault(person => person.Id == p.Id) == null;
        }

        override
        public Person GetPerson(int id)
        {
            var persons = GetPersons();

            return persons.FirstOrDefault(person => person.Id == id);
        }

        override
        public Person UpdatePerson(Person p)
        {
            var persons = GetPersons();
            var personFound = persons.FirstOrDefault(person => person.Id == p.Id);
            if (personFound != null)
            {
                personFound.Name = p.Name;
                SaveData(persons);
            }
            return personFound;

        }

        private void SaveData(List<Person> persons)
        {
            var fs = new FileStream(_filePath, FileMode.Create);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, persons);
            fs.Close();
        }


        private List<Person> LoadData()
        {
            FileStream fs = new FileStream(_filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                var list = bf.Deserialize(fs) as List<Person>;
                fs.Close();

                return list ?? new List<Person>();
            }
            catch (Exception e)
            {
                fs.Close();
                return new List<Person>();
            }
        }
    }
}
