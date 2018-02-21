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
    public class CityManager
    {
        readonly Context _Context = new Context();

        public void Create(City city)
        {
            try
            {
                _Context.Cities.Add(city);
                _Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<City> Get()
        {
            try
            {
                return _Context.Cities;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public City GetById(int id)
        {
            try
            {
                return _Context.Cities.Find(id);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(int id, City city)
        {
            try
            {
                _Context.Entry(city).State = EntityState.Modified;

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
                City city = GetById(id);
                _Context.Cities.Remove(city);
                _Context.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool CityExists(int id)
        {
            return GetById(id) != null;
        }
    }
}
