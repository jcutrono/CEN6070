using CEN6070.Domain;
using MongoDB.Bson;

namespace CEN6070.Data
{
    public interface IPersonDataStore
    {
        ObjectId AddModifyPerson(Person person);
        Person GetPerson(ObjectId id);
    }

    public class PersonDataStore : DataStore, IPersonDataStore
    {
        public ObjectId AddModifyPerson(Person person)
        {
            var people = Database.GetCollection<Person>("Person");
            people.Insert(person);

            return person.Id;
        }

        public Person GetPerson(ObjectId id)
        {
            return Database.GetCollection<Person>("Person").FindOneByIdAs<Person>(id);
        }
    }
}
