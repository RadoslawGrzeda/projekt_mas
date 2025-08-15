using MAS.Models;

namespace MAS
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Person Person = new Person();

            Person person = new Person(
          "Jan",
            "Kowalski",
           new DateOnly(1990, 5, 20),
            "jan.kowalski@example.com",
            123456789,
            PersonType.Customer | PersonType.Employee
            , 12.52, true,"123456"
       );

            // Wyœwietlenie danych
            Console.WriteLine($"Imiê i nazwisko: {person.name} {person.surname}");
            Console.WriteLine($"Email: {person.email}");
            Console.WriteLine($"Wiek: {person.getAge()} lat");
            Console.WriteLine($"Rola: {person.personTypes}");
            //person.id = "test";
            Console.WriteLine($"Rola: {person.id}");

            /*var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }*/
        }
    }
}
