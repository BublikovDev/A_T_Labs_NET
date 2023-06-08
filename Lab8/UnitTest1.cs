using Lab6.Controllers;
using Lab6.Data;
using Lab6.Models;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Lab8
{
    [TestFixture]
    public class PersonServiceTests
    {
        private DbContextOptions<ApplicationDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Test]
        public void CreatePerson_AddsPersonToDatabase()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var service = new PersonService(context);
                var person = new Person { Id = 1, Name = "John" };

                // Act
                service.CreatePerson(person);

                // Assert
                Assert.AreEqual(1, context.Persons.Count());
                Assert.AreEqual(person, context.Persons.FirstOrDefault());
            }
        }

        [Test]
        public void GetPersonById_ReturnsCorrectPerson_WhenPersonExists()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var service = new PersonService(context);
                var person = new Person { Id = 1, Name = "John" };
                context.Persons.Add(person);
                context.SaveChanges();

                // Act
                var result = service.GetPersonById(person.Id);

                // Assert
                Assert.AreEqual(person, result);
            }
        }

        [Test]
        public void GetPersonById_ReturnsNull_WhenPersonDoesNotExist()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var service = new PersonService(context);

                // Act
                var result = service.GetPersonById(1);

                // Assert
                Assert.IsNull(result);
            }
        }

        [Test]
        public void GetPersonById_ReturnsFirstMatchingPerson_WhenMultiplePersonsExist()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_options))
            {
                var service = new PersonService(context);
                var person1 = new Person { Id = 1, Name = "John" };
                var person2 = new Person { Id = 2, Name = "Jane" };
                context.Persons.AddRange(person1, person2);
                context.SaveChanges();

                // Act
                var result = service.GetPersonById(person2.Id);

                // Assert
                Assert.AreEqual(person2, result);
            }
        }
    }
}