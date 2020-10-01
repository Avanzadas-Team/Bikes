using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bikes.Models;

namespace Bikes
{
    public class AppDB : DbContext
    {

        public AppDB(DbContextOptions<AppDB> options) : base(options)
        {
            LoadDefaultUsers();
        }

        public DbSet<WeatherForecast> Summaries { get; set; }
        public List<WeatherForecast> GetSummaries() => Summaries.Local.ToList<WeatherForecast>();

        private void LoadDefaultUsers()
        {
            string[] Summar = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            int i = 0;
            var rng = new Random();

            foreach (string word in Summar)
            {
                Summaries.Add(new WeatherForecast {ID = i, Date = DateTime.Now, TemperatureC = rng.Next(-20, 55), Summary = word });
            }

            Console.WriteLine("Loaded Example Data");
        }
    }
}
