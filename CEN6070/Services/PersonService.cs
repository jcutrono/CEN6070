using System;
using System.Text.RegularExpressions;
using CEN6070.Data;
using CEN6070.Domain;
using MongoDB.Bson;

namespace CEN6070.Services
{
    public class PersonService
    {
        private readonly IPersonDataStore _personDataStore;

        public PersonService(IPersonDataStore dataStore)
        {
            _personDataStore = dataStore;
        }

        public ObjectId AddPerson(Person person)
        {
            // Add logic here to make the test pass 

            if (person.Age >= 0 && person.Age <= 100)
            {
                return _personDataStore.AddModifyPerson(person);
            }

            throw new Exception("Contact Guiness World Book of Records");
        }

        public Person GetPerson(ObjectId id)
        {
            return _personDataStore.GetPerson(id);
        }
    }
}
