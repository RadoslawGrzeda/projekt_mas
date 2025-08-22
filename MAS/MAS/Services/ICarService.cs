using MAS.Models;

namespace MAS.Services
{
    public interface ICarService
    {
        Task<List<Car>>? showCars();
        Task<Action>createCar(Car car);
        

    }
}
