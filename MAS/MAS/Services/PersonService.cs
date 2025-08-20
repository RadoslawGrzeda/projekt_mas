
using MAS.Data;
using MAS.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace MAS.Services
{
    public class PersonService : IPersonService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PersonService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = context;
            _httpContextAccessor = httpContextAccessor;
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


        /*
         * Metoda makeReservation umożliwia klientowi dokonanie rezerwacji samochodu, pobierany jest automatycznie
         * id użytkownika przez HttpContextAccessor, który jest wstrzykiwany do serwisu i sprwdza, czy użytkownik ma rolę klienta.
         * 
         * 
         * 
         */
        public async Task<Reservation> makeReservation(int carId, DateOnly startDate, int numberOfDays)
        {
            if (numberOfDays <= 0)
                throw new ArgumentException("Number of days must be greater than zero.");

            var user = _httpContextAccessor.HttpContext?.User;
            var personIdCl = user?.FindFirst("personId");
            if (personIdCl == null)
                throw new InvalidOperationException("personId claim not found.");

            int personId = int.Parse(personIdCl.Value);

            var person = await _dbContext.Persons.FindAsync(personId);
            if (person == null)
                throw new InvalidOperationException("Person not found.");
            if (!person.hasRole(PersonType.Customer))
                throw new InvalidOperationException("Only customers can make reservations.");

            Car car = await _dbContext.HybridCars.FindAsync(carId);
            if (car == null)
                car = await _dbContext.InternalCombusionsCars.FindAsync(carId);
            if (car == null)
                car = await _dbContext.ElectricCars.FindAsync(carId);
            if (car == null)
                throw new InvalidOperationException("Car not found.");

            var carReservations = _dbContext.Reservations
                .Where(r => r.carId == carId &&
                    (r.reservationStatus == ReservationStatus.inProgress || r.reservationStatus == ReservationStatus.scheduled));

            if (carReservations.Any(r =>
                r.dateOfReservation <= startDate.AddDays(numberOfDays - 1) &&
                r.dateOfReservation.AddDays(r.numberOfDays - 1) >= startDate))
            {
                throw new InvalidOperationException("Car is already reserved for the selected dates.");
            }

            var today = DateOnly.FromDateTime(DateTime.Today);
            var reservationStatus = startDate > today ? ReservationStatus.scheduled : ReservationStatus.inProgress;

            var reservation = new Reservation
            {
                dateOfReservation = startDate,
                numberOfDays = numberOfDays,
                personId = personId,
                carId = carId,
                reservationStatus = reservationStatus
            };

            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();
            return reservation;
        }
    }
}
