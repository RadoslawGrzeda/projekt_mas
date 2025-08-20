namespace MAS.DTOs
{
    public class MakeReservationDto
    {
        public int CarId { get; set; }
        public DateOnly StartDate { get; set; }
        public int NumberOfDays { get; set; }
    }
}
