namespace MAS.Models
{
    [Flags]
    public enum ReservationStatus
    {
        None      = 0,
        scheduled   = 1,
        inProgress = 1<<1,
        finished= 1<<2,
        canceled = 1<<3,
    }
   
}
