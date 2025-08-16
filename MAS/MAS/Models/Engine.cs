
using System.ComponentModel.DataAnnotations;

namespace MAS.Models

{
    public class Engine
    {
        public int enginePower{ get; set; }
        public double capacity { get; set; }
        public FuelTypes fuelType { get; set; }

        //public Car getCar()
        //{
        //    return car
        //}
    }
}
