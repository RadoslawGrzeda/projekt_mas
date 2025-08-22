namespace MAS.DTOs.View
{
    public class CarCardVm
    {
        public int Id { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public double DailyRate { get; set; }
        public double Deposit { get; set; }
    }
}
