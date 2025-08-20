using MAS.Data;
using MAS.Models;

namespace MAS.Services
{
    public class CarService 
    {
        private readonly DatabaseContext _dbContext;
        public CarService (DatabaseContext context)
        {
            _dbContext = context;
        }

        //public Task<Car> createCar(Car car)
        //{
        //    var
        //}
    }
}
