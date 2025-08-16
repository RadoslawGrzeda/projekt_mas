using System.Reflection.Metadata.Ecma335;

namespace MAS.Models
{
    public class Reservation
    {
        public DateOnly dateOfReservation { get; set; }
        public ReservationStatus reservationStatus { get; set; }
        public int numberOfDays { get; set; }
        public string? reason { get; set; }
        public bool deposit { get; set; } = false;

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
