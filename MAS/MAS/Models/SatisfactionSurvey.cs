using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Models
{
    
    public class SatisfactionSurvey
    {
        [Key]
        [ForeignKey(nameof(reservation))]
        public int reservationId { get; set; }

        [Range(1, 5)]
        public int rating { get; set; }

        public string description { get; set; }

        //public int customerId { get; set; }
        //public Person customer { get; set; } = null!;

        // Required dependent navigation - survey cannot exist without reservation
        public Reservation reservation { get; set; } = null!;
    }
}
