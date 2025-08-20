using MAS.Models;

namespace MAS.Services
{
    public interface IPersonService
    {
          Task<Person> CreatePerson(Person person);
          Task<List<Person>> GetAllPerson();

        //Customer
        Task<Reservation> makeReservation(int carId, DateOnly startDate, int numberOfDays);

    }


}
