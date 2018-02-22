using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.DL
{
    public class Context : DbContext
    {
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<City> Cities { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);
        //}

        public class WA_BDInitializer : DropCreateDatabaseIfModelChanges<Context>
        {

            protected override void Seed(Context context)
            {
                var cities = new List<City>{
                    new City { Name = "Warsaw" },
                    new City { Name = "Gdansk" },
                    new City { Name = "Poznan" },
                    new City { Name = "Torun" },
                    new City { Name = "Lublin" },
                    new City { Name = "Poznan" },
                    new City { Name = "Cracow" },
                };
                cities.ForEach(c => context.Cities.Add(c));

                var weatherList = new List<Weather>
                {
                    new Weather
                    {
                        City = cities[0],
                        Condition = "Sunny",
                        Date = DateTime.Now,
                        TempMax = 8,
                        TempMin = 1,
                        RealFeel = -1
                    },
                    new Weather
                    {
                        City = cities[0],
                        Condition = "Cloudy",
                        Date = DateTime.Now.AddDays(1),
                        TempMax = 5,
                        TempMin = 0,
                        RealFeel = 0
                    },
                    new Weather
                    {
                        City = cities[0],
                        Condition = "Windy",
                        Date = DateTime.Now.AddDays(2),
                        TempMax = 3,
                        TempMin = -1,
                        RealFeel = -3
                    },
                    new Weather
                    {
                        City = cities[1],
                        Condition = "Sunny",
                        Date = DateTime.Now.AddDays(3),
                        TempMax = 8,
                        TempMin = 1,
                        RealFeel = -1
                    },
                    new Weather
                    {
                        City = cities[0],
                        Condition = "Cloudy",
                        Date = DateTime.Now.AddDays(4),
                        TempMax = 5,
                        TempMin = 0,
                        RealFeel = 0
                    },
                    new Weather
                    {
                        City = cities[1],
                        Condition = "Sunny",
                        Date = DateTime.Now,
                        TempMax = 8,
                        TempMin = 1,
                        RealFeel = -1
                    },
                    new Weather
                    {
                        City = cities[1],
                        Condition = "Cloudy",
                        Date = DateTime.Now.AddDays(1),
                        TempMax = 5,
                        TempMin = 0,
                        RealFeel = 0
                    },
                    new Weather
                    {
                        City = cities[1],
                        Condition = "Cloudy",
                        Date = DateTime.Now.AddDays(2),
                        TempMax = 5,
                        TempMin = 0,
                        RealFeel = 0
                    },
                    new Weather
                    {
                        City = cities[2],
                        Condition = "Sunny",
                        Date = DateTime.Now,
                        TempMax = 8,
                        TempMin = 1,
                        RealFeel = -1
                    },
                    new Weather
                    {
                        City = cities[2],
                        Condition = "Windy",
                        Date = DateTime.Now.AddDays(1),
                        TempMax = 3,
                        TempMin = -1,
                        RealFeel = -3
                    },
                    new Weather
                    {
                        City = cities[2],
                        Condition = "Sunny",
                        Date = DateTime.Now.AddDays(2),
                        TempMax = 8,
                        TempMin = 1,
                        RealFeel = -1
                    },
                    new Weather
                    {
                        City = cities[2],
                        Condition = "Cloudy",
                        Date = DateTime.Now.AddDays(3),
                        TempMax = 5,
                        TempMin = 0,
                        RealFeel = 0
                    },
                };
                weatherList.ForEach(w => context.Weathers.Add(w));

                base.Seed(context);
            }
        }
    }
}
