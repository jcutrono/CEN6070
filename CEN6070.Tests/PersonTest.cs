using System;
using CEN6070.Data;
using CEN6070.Domain;
using CEN6070.Services;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;

namespace CEN6070.Tests
{
    public class PersonTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(99)]
        [TestCase(100)]
        public void Test_PersonService_AddPerson(int age)
        {
            // Arrange
            ObjectId id = new ObjectId();
            Mock<IPersonDataStore> mockPersonDataStore = new Mock<IPersonDataStore>();
            mockPersonDataStore.Setup(x => x.AddModifyPerson(It.IsAny<Person>())).Returns(id);
            PersonService sut = new PersonService(mockPersonDataStore.Object);

            // Act
            ObjectId personId = sut.AddPerson(new Person { Age = age });

            // Assert
            Assert.That(personId, Is.EqualTo(id));
        }

        [TestCase(-1)]
        [TestCase(101)]
        public void Test_PersonService_NegativeAge(int age)
        {
            // Arrange
            ObjectId id = new ObjectId();
            Mock<IPersonDataStore> mockPersonDataStore = new Mock<IPersonDataStore>();
            mockPersonDataStore.Setup(x => x.AddModifyPerson(It.IsAny<Person>())).Returns(id);
            PersonService sut = new PersonService(mockPersonDataStore.Object);

            // Act
            // Assert
            Exception e = Assert.Throws<Exception>(() => sut.AddPerson(new Person { Age = age }));
            Assert.That(e.Message, Is.EqualTo("Contact Guiness World Book of Records"));
        }

        [Test]
        public void Test_Person_FirstName_Fail()
        {
            // Arrange
            ObjectId id = new ObjectId();
            Mock<IPersonDataStore> mockPersonDataStore = new Mock<IPersonDataStore>();
            mockPersonDataStore.Setup(x => x.AddModifyPerson(It.IsAny<Person>())).Returns(id);
            PersonService sut = new PersonService(mockPersonDataStore.Object);

            // Act

            // Assert
            Exception e = Assert.Throws<Exception>(() => sut.AddPerson(new Person { Age = 30, FirstName = "@lbert" }));
        }
    }
}
