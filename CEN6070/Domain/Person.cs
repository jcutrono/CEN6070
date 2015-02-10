
namespace CEN6070.Domain
{
    public class Person : MongoDocument
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Female,
        Male
    }
}
