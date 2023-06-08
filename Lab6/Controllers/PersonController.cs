using Lab6.Data;
using Lab6.Models;
using Lab6.Models.Requests;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly PersonService _personService;

      

        public PersonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _personService = new PersonService(_dbContext);
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAllPersons()
        {
            var persons = _personService.GetAllPersons();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonById(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] CreatePersonRequest person)
        {
            var newPerson = new Person()
            {
                Name = person.Name,
                Age = person.Age,
                IsMarried = person.IsMarried,
                Address=new Address() { City = person.City, State=person.State},
                PhoneNumbers = new List<PhoneNumber>(),
                Interests = new List<Interest>()
            };

            foreach (var phone in person.PhoneNumbers)
            {
                newPerson.PhoneNumbers.Add(new PhoneNumber() { Number = phone });
            }
            foreach (var interest in person.Interests)
            {
                newPerson.Interests.Add(new Interest() { Name = interest });
            }

            _personService.CreatePerson(newPerson);
            return CreatedAtAction(nameof(GetPersonById), new { id = newPerson.Id }, newPerson);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Person updatedPerson)
        {
            if (id != updatedPerson.Id)
            {
                return BadRequest();
            }

            _personService.UpdatePerson(updatedPerson);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            _personService.DeletePerson(id);
            return NoContent();
        }
    }
}
