using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePerson(Person person)
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
        }

        public Person GetPersonById(int id)
        {
            return _dbContext.Persons.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePerson(Person updatedPerson)
        {
            var existingPerson = _dbContext.Persons.FirstOrDefault(p => p.Id == updatedPerson.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = updatedPerson.Name;
                existingPerson.Age = updatedPerson.Age;
                existingPerson.IsMarried = updatedPerson.IsMarried;
                // Update other properties as needed
                _dbContext.SaveChanges();
            }
        }

        public void DeletePerson(int id)
        {
            var person = _dbContext.Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _dbContext.Persons.Remove(person);
                _dbContext.SaveChanges();
            }
        }

        public List<Person> GetAllPersons()
        {
            return _dbContext.Persons.ToList();
        }
    }
}
