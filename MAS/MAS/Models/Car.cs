namespace MAS.Models
{
    public enum roofType
    {
        None       = 0,
        removable  = 1,
        foldable   = 1<<1
    }
    public abstract class Car
    {                             
        public BodyType BodyType { get; set; }
        public string brand { get; set; }
        public string model { get; set; }   
        public DateOnly productionYear { get; set; }
        public roofType roofType { get; set; }
        public int numberOfPassangers { get; set; }

        //roof
        //roof
        //engine
        public double? timeToGoundred { get; set; }
        public bool? drive4x4 { get; set; }
        public bool? offRoad { get; set; }
        public double dailyRate { get; set; }
        public double deposit { get; set; }
        public string condition { get; set; }
        public double  mileage { get; set; }
        public ICollection<Reservation>? reservations { get; set; }
        public ICollection<Person>? prepared{ get; set; }

        public Car (BodyType bodyType,roofType roofType,int numberOfPassangers, string brand, string model, DateOnly productionYear, double? timeToGoundred, bool? drive4x4, bool? offRoad, double dailyRate, double deposit, string condition, double mileage)
        {
            BodyType = bodyType;
            this.brand = brand;
            this.model = model;
            this.productionYear = productionYear;
            this.dailyRate = dailyRate;
            this.condition = condition;
            this.mileage = mileage;
            this.deposit = deposit;

            if (bodyType.HasFlag(BodyType.Van))
                this.numberOfPassangers = numberOfPassangers; 

            if (bodyType.HasFlag(BodyType.Sport))
                this.timeToGoundred = timeToGoundred;

            if (bodyType.HasFlag(BodyType.Suv))
            {   this.drive4x4 = drive4x4;
                this.offRoad = offRoad;
            }
            
            if(bodyType.HasFlag(BodyType.Cabriolet))
                this.roofType = roofType;
    
        }
        //public void checkType(BodyType bt)
        //{
        //    if(bt )

        //}

        public static void showCars()
        {

        }
        public void removeCar()
        {

        }
        public void getEngine()
        {

        }
        //getReservations():
        //getEmploteesPreparing();
        //showReservations()
        
    }
}
