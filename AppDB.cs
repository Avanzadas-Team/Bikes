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
            // LoadDefaultUsers();
        }

        public DbSet<WeatherForecast> Summaries { get; set; }
        public DbSet<clientes> Clientes { get; set; }
        public DbSet<ordenesNewYork> ordenesNY { get; set; }
        public DbSet<ordenesCalifornia> ordenesCA { get; set; }
        public DbSet<ordenesTexas> ordenesTX { get; set; }
        public List<WeatherForecast> GetSummaries() => Summaries.Local.ToList<WeatherForecast>();
        public List<clientes> GetClients()
        {
            const int BESTCLIENTS = 3;

            List<clientes> clients = this.Clientes.Local.ToList<clientes>();
            List<ordenesNewYork> ny = this.ordenesNY.Local.ToList<ordenesNewYork>();
            List<ordenesCalifornia> ca = this.ordenesCA.Local.ToList<ordenesCalifornia>();
            List<ordenesTexas> tx = this.ordenesTX.Local.ToList<ordenesTexas>();
            List<ordenes> ordenes = ny.Concat<ordenes>(ca).ToList<ordenes>().Concat<ordenes>(tx).ToList<ordenes>();

            Dictionary<clientes, int> clientsBoughts = new Dictionary<clientes, int>();
            List<clientes> newClients = new List<clientes>();
            foreach(clientes cl in clients)
            {
                if (clientsBoughts.ContainsKey(cl))
                {
                    int cuant;
                    clientsBoughts.TryGetValue(cl, out cuant);
                    clientsBoughts[cl] =  cuant++;
                }
                else
                {
                    clientsBoughts.Add(cl, 1);
                }
            }

            clientsBoughts.OrderBy(key => key.Value);

            if(clientsBoughts.Count > 0)
                for (int i = 0; i < BESTCLIENTS; i++)
                    newClients.Add(clientsBoughts.ElementAt(i).Key);

            return newClients;
        }
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
