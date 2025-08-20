using MAS.Models;

namespace MAS.Services
{
    public interface ICarService
    {
        Task<Car>createCar(Car car);
        

    }
}
