using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Models
{
    public class Rental
    {
        [Key]
        public int id { get; set; }
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
        public int reservationId { get; set; }
        public int contractId{ get; set; }

        [ForeignKey(nameof(reservationId))]
        public Reservation Reservation { get; set; }

        [ForeignKey(nameof(contractId))]
        public Contract contract { get; set; } 
        //public  MyProperty { get; set; }
        //ankieta

    }

}
