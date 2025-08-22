using System.ComponentModel.DataAnnotations;

namespace MAS.DTOs.View
{
    public class CarBrowseVm
    {
 public string UserName { get; set; } = "Jan Nowak";
    public int CompletedReservations { get; set; } = 10;

    [Display(Name = "Data rozpoczęcia")]
    [DataType(DataType.Date)]
    [Required]
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

    [Display(Name = "Liczba dni")]
    [Range(1, 60)]
    public int NumberOfDays { get; set; } = 3;

    public string? Message { get; set; }
    public List<CarCardVm> Cars { get; set; } = new();
}
}