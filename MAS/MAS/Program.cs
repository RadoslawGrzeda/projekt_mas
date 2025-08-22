using MAS.Data;
using MAS.Models;
using MAS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
namespace MAS
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>(options =>
              options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<PersonService>();
            //builder.Services.AddScoped<IPersonService>();

            builder.Services.AddScoped<ReservationService>();
            //builder.Services.AddScoped<IReservationService>();

            builder.Services.AddScoped<RentalService>();
            //builder.Services.AddScoped<IRentalService>();

            builder.Services.AddScoped<CarService>();
            //builder.Services.AddScoped<ICarService>();


            builder.Services.AddScoped<IPersonService, PersonService>();
            //builder.Services.AddScoped<IReservationService, ReservationService>();
            //builder.Services.AddScoped<IRentalService, RentalService>();
            builder.Services.AddScoped<ICarService, CarService>();

            builder.Services.AddDbContext<DatabaseContext>(opt => opt
    .UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging());


            builder.Services.AddHttpContextAccessor();



            //var app = builder.Build();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();
            if (app.Environment.IsDevelopment())
            {
                app.Use(async (ctx, next) =>
                {
                    if (ctx.User?.Identity?.IsAuthenticated != true)
                    {
                        var claims = new[]
                        {
                new Claim(ClaimTypes.Name, "jan.nowak@example.com"),
                new Claim("personId", "1"),           // << USTAW ID ISTNIEJ¥CEJ OSOBY W DB
                new Claim(ClaimTypes.Role, "Customer")
            };
                        var identity = new ClaimsIdentity(claims, "DevAuth");
                        ctx.User = new ClaimsPrincipal(identity);
                    }
                    await next();
                });
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthorization();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Cars}/{id?}");

            app.Run();
        }
    }
}

