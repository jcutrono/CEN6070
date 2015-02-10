using System;
using Autofac;
using CEN6070.Data;
using CEN6070.Domain;
using CEN6070.Services;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                PersonService service = new PersonService(scope.Resolve<IPersonDataStore>());

                Console.WriteLine(service.AddPerson(new Person { FirstName = "Albert", LastName = "Alligator", Age = 25, Gender = Gender.Male }));
                Console.ReadLine();
            }
        }
    }

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PersonDataStore>().As<IPersonDataStore>();

            return builder.Build();
        }
    }
}
