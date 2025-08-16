namespace MAS.Models
{
    [Flags]
    public enum BodyType
    {
        None      = 0,
        Van       = 1,
        Suv       = 1<<1,
        Cabriolet = 1<<2,
        Sport     = 1<<3,
    }
}
