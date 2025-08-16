namespace MAS.Models
{
    public class Rental
    {
        public DateOnly rentalDate { get; set; }
        public DateOnly? returnDate { get; set; }
        public double rentalStartMileage { get; set; }  
        public double? kilometersDriven { get; set; }
        public string vehicleConditionAtStart { get; set; }
        public string? vehicleConditionAfterReturn { get; set; }
        public double? totalCost { get; set; }
        public double? penalty { get; set; }
        public RentalStatus rentalStatus { get; set; }
        public Person preparedByEmployee{ get; set; }

        public Person handledByEmployee { get; set; }
        public bool isPrepared { get; set; } = false;
        //public  MyProperty { get; set; }
        //ankieta

    }

}
