using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpamEntities;

namespace DataLogicLayer.Managers
{
    public class ProxyPersonManager : IPersonManager
    {
        public List<Person> GetPersons()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("https://easv-person.herokuapp.com/api/persons/").Result;
                return response.Content.ReadAsAsync<List<Person>>().Result;
            }
        }

        public Person AddPerson(Person p)
        {
            using (var client = new HttpClient())
            {
                var formatter = new JsonMediaTypeFormatter();
                formatter.SerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                HttpResponseMessage response =
                    client.PostAsync("https://easv-person.herokuapp.com/api/persons/", p, formatter).Result;
                return response.Content.ReadAsAsync<Person>().Result;
            }
        }
    }
}
