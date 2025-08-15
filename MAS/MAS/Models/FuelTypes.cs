namespace MAS.Models.Person
{
    [Flags]
    public enum PersonType
    {
        None      = 0,
        Employee  = 1,
        Customer  = 1<<1,
        Admin     = 1<<2,
    }
}
