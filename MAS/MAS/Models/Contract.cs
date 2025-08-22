using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Models
{
    public class Contract
    {
        [Key]
        [ForeignKey(nameof(Rental))]
        public int rentalId { get; set; }
        public bool contractNumber { get; set; }
        public DateOnly contractDate { get; set; }
        public double deposit { get; set; }


        public Rental Rental { get; set; }
    }
}
