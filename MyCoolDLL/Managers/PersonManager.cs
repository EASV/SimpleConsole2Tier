using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MyCoolDLL.Entities;

namespace MyCoolDLL.Managers
{
    internal class PersonManager : IManager<Person>
    {
        private readonly string _filePath =
            AppDomain.CurrentDomain.BaseDirectory + "persons.dat";

        public Person Create(Person t)
        {
            var persons = ReadAll();
            var maxId = 0;
            if (persons.Any())
            {
                maxId = persons.Max(x => x.Id);
            }
            t.Id = ++maxId;
            persons.Add(t);
            SaveData(persons);
            return t;
        }

        public List<Person> ReadAll()
        {
            return LoadData();
        }

        public Person Read(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id == id);
            /*var found = ReadAll().FirstOrDefault(x => x.Id == id);
            if (found == null)
            {
                throw new InvalidDataException();
            }
            return found ;*/

        }

        public Person Update(Person t)
        {
            if (t == null || t.Id < 1)
            {
                throw new InvalidDataException();
            }
            var persons = ReadAll();

            //Find the index and override the old person
            /*var index = persons.FindIndex(x => x.Id == t.Id);
            if (index > 0)
            {
                persons[index] = t;
            }*/

            //Find the person and override each property
            var person = persons.FirstOrDefault(x => x.Id == t.Id);
            if (person != null)
            {
                person.Name = t.Name;
                person.Email = t.Email;
                //Etc...
            }
            SaveData(persons);

            return t;
        }

        public bool Delete(int id)
        {
            var persons = ReadAll();
            var done = persons.RemoveAll(x => x.Id == id) > 0;
            SaveData(persons);
            return done;

        }


        private void SaveData(List<Person> persons)
        {
            /*using (var fs2 = new FileStream(_filePath, FileMode.Create))
            {
                var bf2 = new BinaryFormatter();
                bf2.Serialize(fs2, persons);
            }*/

            
            var fs = new FileStream(_filePath, FileMode.Create);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, persons);
            fs.Close();
        }
        
        private List<Person> LoadData()
        {
            var fs = new FileStream(_filePath, FileMode.OpenOrCreate);
            var bf = new BinaryFormatter();
            try
            {
                var list = bf.Deserialize(fs) as List<Person>;
                fs.Close();

                //return list != null ? list : new List<Person>();
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
