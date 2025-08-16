
using MAS.Data;
using MAS.Models;
using System.Data.Entity;

namespace MAS.Services
{
    public class PersonService : IPersonServicecs
    {
        private readonly DatabaseContext _dbContext;

        public PersonService(DatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }

        public async Task<List<Person>> GetAllPerson()
        {
            return await _dbContext.Persons.ToListAsync();
        }
    }
}
