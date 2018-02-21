using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DL;
using WeatherApp.Model;

namespace WeatherApp.BL
{
    public class WeatherManager
    {
        readonly Context _Context = new Context();

        public void Create (Weather weather)
        {
            try
            {
                _Context.Weathers.Add(weather);
                _Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Weather> Get()
        {
            try
            {
                return _Context.Weathers;

            }
            catch (Exception e)
            {

                throw e;
            }        }

        public Weather GetById(int id)
        {
            try
            {
                return _Context.Weathers.Find(id); //.SingleOrDefault(w => w.Id == id);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(int id, Weather weather)
        {
            try
            {
                //Weather dbWeather = GetById(id);
                //dbWeather.FKCityId = weather.FKCityId;
                //dbWeather.Condition = weather.Condition;
                //dbWeather.RealFeel = weather.RealFeel;
                //dbWeather.TempMax = weather.TempMax;
                //dbWeather.TempMin = weather.TempMin;

                _Context.Entry(weather).State = EntityState.Modified;

                //_Context.Weathers.Attach(dbWeather);
                _Context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Weather weather = GetById(id);
                _Context.Weathers.Remove(weather);
                _Context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool WeatherExists(int id)
        {
            return GetById(id) != null;
        }

    }
}
