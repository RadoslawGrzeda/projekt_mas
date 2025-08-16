
namespace MAS.Models
{
    public class Electric : Car
    {
        public double range { get; set; }
        public Electric(BodyType bodyType,double range, roofType roofType, int numberOfPassangers, string brand, string model, DateOnly productionYear, double? timeToGoundred, bool? drive4x4, bool? offRoad, double dailyRate, double deposit, string condition, double mileage) : base(bodyType, roofType, numberOfPassangers, brand, model, productionYear, timeToGoundred, drive4x4, offRoad, dailyRate, deposit, condition, mileage)
        {
            this.range = range;
        }

        
    }
}
