using System.ComponentModel.DataAnnotations;

namespace MAS.Models
{
    public class Hybrid : Car
    {
        public Hybrid() { }
        //Electric engine
        public Hybrid(BodyType bodyType, roofType roofType, int numberOfPassangers, string brand, string model, DateTime productionYear, double? timeToGoundred, bool? drive4x4, bool? offRoad, double dailyRate, double deposit, string condition, double mileage)
            : base(bodyType, roofType, numberOfPassangers, brand, model, productionYear, timeToGoundred, drive4x4, offRoad, dailyRate, deposit, condition, mileage)
        {
        }
    }
}
