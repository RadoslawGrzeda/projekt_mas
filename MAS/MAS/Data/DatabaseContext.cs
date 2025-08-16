using MAS.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Reflection.PortableExecutable;

namespace MAS.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected DatabaseContext() { }
        
        public DatabaseContext(DbContextOptions options) : base(options) { }
    }
}
