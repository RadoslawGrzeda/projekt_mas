namespace MAS.Models
{
    [Flags]
    public enum FuelTypes
    {
        None      = 0,
        petrol    = 1,
        diesel    = 1<<1,
        electric  = 1<<2,
    }
}
