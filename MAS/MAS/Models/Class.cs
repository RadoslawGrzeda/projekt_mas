namespace MAS.Models
{
    public enum ReservationStatus
    {
        scheduled   = 0,
        inProgress  = 1,
        finished    = 1<<1,
        canceled    = 1<<2
    }
}
