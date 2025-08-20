using MAS.Data;
using MAS.Models;
using MAS.Services;
using Microsoft.EntityFrameworkCore;
using System;

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
            builder.Services.AddScoped<PersonService>();

            builder.Services.AddScoped<ReservationService>();
            builder.Services.AddScoped<IReservationService>();

            builder.Services.AddScoped<RentalService>();
            builder.Services.AddScoped<IRentalService>();

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

            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthorization();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

