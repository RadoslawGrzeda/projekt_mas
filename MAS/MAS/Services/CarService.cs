using MAS.Data;
using MAS.Models;
using Microsoft.EntityFrameworkCore;

namespace MAS.Services
{
    public class CarService : ICarService
    {
        private readonly DatabaseContext _dbContext;
        public CarService(DatabaseContext context)
        {
            _dbContext = context;
        }

        public Task<Action> createCar(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Car>> showCars()
        {
            var cars = await _dbContext.Cars.ToListAsync();

           //if (cars is null || cars.Count == 0)
           // {
           //     throw new Exception("No cars found.");

           // }
            return cars;



            //public Task<Car> createCar(Car car)
            //{
            //    var
            //}
        } } }

