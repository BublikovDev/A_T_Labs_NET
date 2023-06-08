using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;
using Lab6.Services;

namespace Lab6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public DefaultController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TestPerson()
        {
            var personService = new PersonService(_dbContext);

            // Create a new person

            Address newAddress = new Address() { City = "Kyiv", State = "Ukraine" };
            Interest newInterest = new Interest() { Name = "ComputerGames" };
            PhoneNumber newPhoneNumber = new PhoneNumber() { Number= "0988887766" };

            Person newPerson = new Person
            {
                Name = "John",
                Age = 30,
                IsMarried = true,
                Address= newAddress,
                Interests = new List<Interest>() { newInterest },
                PhoneNumbers = new List<PhoneNumber>() { newPhoneNumber }
            };

            personService.CreatePerson(newPerson);

            // Retrieve a person by ID
            var lastPerson = await _dbContext.Persons.FirstOrDefaultAsync();
            Person retrievedPerson = personService.GetPersonById(lastPerson.Id);
            Console.WriteLine($"Retrieved Person: {retrievedPerson.Name}");

            // Update a person
            retrievedPerson.Name = "Updated John";
            personService.UpdatePerson(retrievedPerson);

            // Get all persons
            List<Person> allPersons = personService.GetAllPersons();
            foreach (var person in allPersons)
            {
                Console.WriteLine($"Person: {person.Name}");
            }

            // Delete a person
            personService.DeletePerson(lastPerson.Id);

           
            return Ok();
        }
    }
}
