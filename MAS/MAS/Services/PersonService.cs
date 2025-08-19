
using MAS.Data;
using MAS.Models;
using System.Data.Entity;
using Microsoft.AspNetCore.Http;

namespace MAS.Services
{
    public class PersonService : IPersonServicecs
    {
        private readonly DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
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


        public async Task<Reservation> makeReservation(int carId, DateOnly startDate, int numberOfDays)
        {
            if (numberOfDays <= 0)
                throw new ArgumentException("Number of days must be greater than zero.");
            var user = _httpContextAccessor.HttpContext?.User;
            var personIdCl = user?.FindFirst("personId");
            if(personIdCl == null)
            throw new InvalidOperationException("personId claim not found.");
            
            int personId= int.Parse(personIdCl.Value);

            var person= await _dbContext.Persons.FindAsync(personId);
            if (person == null)
                throw new InvalidOperationException("Person not found.");
            if (!person.hasRole(PersonType.Customer))
                throw new InvalidOperationException("Only customers can make reservations.");

            var car = await _dbContext.HybridCars.FindAsync(carId);
            if (car == null)
            {
                await _dbContext.InternalCombusionsCars.FindAsync(carId);
            }
            if (car == null)
            {
                await _dbContext.ElectricCars.FindAsync(carId);
            }
            if (car == null)
            {
                throw new InvalidOperationException("Car not found.");
            }

            var carReservations = _dbContext.Reservations
                                .Where(r => r.carId == carId && ReservationStatus.Pending == r.reservationStatus)

            if (carReservations.Any(r => !(r.dateOfReservation < startDate.AddDays(numberOfDays - 1) &&
                                         r.dateOfReservation.AddDays(r.numberOfDays - 1) > startDate))) ;
                th

                var reservation = new Reservation
            {
                dateOfReservation = startDate,
                numberOfDays = numberOfDays,
                personId = personId,
                carId = carId,
                reservationStatus = ReservationStatus.Pending
            };



        }
    }
}
