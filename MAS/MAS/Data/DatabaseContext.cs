using MAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAS.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Car> Cars { get; set; } // base set for TPH
                                             //public DbSet<Hybrid> HybridCars { get; set; }
                                             //public DbSet<Electric> ElectricCars { get; set; }
                                             //public DbSet<InternalCombusion> InternalCombusionsCars { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SatisfactionSurvey> SatisfactionSurveys { get; set; }

        protected DatabaseContext() { }
        public DatabaseContext(DbContextOptions options) : base(options) { }

        // PLAN (pseudocode):
        // - Add a global convention to ensure all DateTime/DateTime? are treated as UTC.
        // - Configure conversion to UTC on save and mark as UTC on read.
        // - Keep storage type as "timestamp with time zone" to match Npgsql expectations.
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
        //        v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
        //        v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        //    var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
        //        v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v.Value : v.Value.ToUniversalTime()) : v,
        //        v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

        //    configurationBuilder.Properties<DateTime>()
        //                        .HaveConversion(dateTimeConver mter)
        //                        .HaveColumnType("timestamp with time zone");

        //    configurationBuilder.Properties<DateTime?>()
        //        .HaveConversion(nullableDateTimeConverter)
        //        .HaveColumnType("timestamp with time zone");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);

    // GLOBALNIE: wszystkie DateTime -> 'timestamp without time zone'
    foreach (var entity in modelBuilder.Model.GetEntityTypes())
    {
        foreach (var p in entity.GetProperties())
        {
            if (p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))
                p.SetColumnType("timestamp without time zone");
        }
    }

            // TPH mapping for Car hierarchy

            modelBuilder.Entity<Car>().HasKey(c => c.id);

            modelBuilder.Entity<Car>()
                .HasDiscriminator<string>("CarType")
                .HasValue<Electric>("Electric")
                .HasValue<Hybrid>("Hybrid")
                .HasValue<InternalCombusion>("InternalCombusion");


            modelBuilder.Entity<Person>()
      .Property(p => p.dateOfBirth)
      .HasColumnType("timestamp without time zone"); // lub zmień typ na DateOnly -> 'date'

            modelBuilder.Entity<Person>()
                .Property(p => p.registrationDate)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Car>()
                .Property(c => c.productionYear)
                .HasColumnType("timestamp without time zone");

            // Jeśli gdzieś masz DateOnly -> daj explicite 'date'
            modelBuilder.Entity<Reservation>()
                .Property(r => r.dateOfReservation)
                .HasColumnType("date");

            // ---- Persons ----
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    personId = 1,
                    name = "Jan",
                    surname = "Kowalski",
                    dateOfBirth = new DateTime(1990, 5, 15),
                    email = "jan.kowalski@example.com",
                    phoneNumber = "123456789",
                    personTypes = PersonType.Customer,
                    registrationDate = new DateTime(2025, 8, 21),
                    id = "PERSON/2025/1",
                    idNumber = "ABC123",
                    drivingLicense = true
                },
                new Person
                {
                    personId = 2,
                    name = "Ewa",
                    surname = "Nowak",
                    dateOfBirth = new DateTime(1985, 3, 20),
                    email = "ewa.nowak@example.com",
                    phoneNumber = "987654321",
                    personTypes = PersonType.Employee,
                    hourlyRate = 40,
                    drivingLicense = true
                }
            );

            // ---- Cars ----
            modelBuilder.Entity<Hybrid>().HasData(
                new Hybrid
                {
                    id = 1,
                    BodyType = BodyType.Suv,
                    brand = "Toyota",
                    model = "RAV4",
                    productionYear = new DateTime(2021, 1, 1),
                    roofType = roofType.None,
                    numberOfPassangers = 5,
                    drive4x4 = true,
                    offRoad = true,
                    dailyRate = 200,
                    deposit = 1000,
                    condition = "Good",
                    mileage = 35000
                }
            );

            modelBuilder.Entity<Electric>().HasData(
                new Electric
                {
                    id = 2,
                    BodyType = BodyType.Sport,
                    brand = "Tesla",
                    model = "Model 3",
                    productionYear = new DateTime(2022, 1, 1),
                    roofType = roofType.None,
                    numberOfPassangers = 5,
                    timeToGoundred = 3.5,
                    dailyRate = 300,
                    deposit = 1500,
                    condition = "Excellent",
                    mileage = 15000
                }
            );

            modelBuilder.Entity<InternalCombusion>().HasData(
                new InternalCombusion
                {
                    id = 3,
                    BodyType = BodyType.Van,
                    brand = "Ford",
                    model = "Transit",
                    productionYear = new DateTime(2019, 1, 1),
                    roofType = roofType.None,
                    numberOfPassangers = 9,
                    dailyRate = 180,
                    deposit = 800,
                    condition = "Used",
                    mileage = 120000
                }
            );
        }
    }
}
