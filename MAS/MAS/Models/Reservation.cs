using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MAS.Models
{
    public class Reservation
    {
        [Key]
        public int id { get; set; }
        public DateOnly dateOfReservation { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public int numberOfDays { get; set; }
        public string? reason { get; set; }
        public bool deposit { get; set; } = false;
        
        public int personId { get; set; }
        public int carId { get; set; }
        public int? rentalId { get; set; }
        //public int? satisfactionSurveyId { get; set; }

        [ForeignKey(nameof(personId))]
        public Person customer { get; set; }=null!;

        [ForeignKey(nameof(carId))]
        public Car car { get; set; } = null!;


        [ForeignKey(nameof(rentalId))]
        public Rental? Rental{ get; set;}

        //[ForeignKey(nameof(satisfactionSurveyId))]
        public SatisfactionSurvey? satisfactionSurvey { get; set; }


        public void removeReservation()
        {

        }
        public static void deleteReservation()
        {

        }
        public void updateStatus()
        {

        }
        public void markDepositPaid()
        {

        }
        public void removeReservation(String reason)
        {

        }
        public void getCar()
        {

        }

    }
}
