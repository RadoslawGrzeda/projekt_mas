
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Models

{
    public class Engine
    {
        public int enginePower{ get; set; }
        public double capacity { get; set; }
        public FuelTypes fuelType { get; set; }

        [Key]
        [ForeignKey(nameof(car))]
        public int carId { get; set; }

        public Car car { get; set; }
        //public Car getCar()
        //{
        //    return car
        //}
    }
}
