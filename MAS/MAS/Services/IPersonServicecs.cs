using MAS.Models;

namespace MAS.Services
{
    public interface IPersonServicecs
    {
          Task<Person> CreatePerson(Person person);
          Task<List<Person>> GetAllPerson();
    }
}
