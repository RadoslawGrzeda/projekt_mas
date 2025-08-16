namespace MAS.Models
{
    public class SatisfactionSurvey
    {
        public int rating { get; set; }
        public string description { get; set; }
        public Person customer { get; set; }
        //public Rental rental { get; set; }
    }
}
