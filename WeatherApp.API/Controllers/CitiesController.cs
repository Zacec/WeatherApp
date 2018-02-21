using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherApp.DL;
using WeatherApp.BL;
using WeatherApp.Model;
using System.Web.Http.Cors;

namespace WeatherApp.API.Controllers
{
    [AllowCors()]//[EnableCors(origins: "http://localhost:50916", headers: "*", methods: "*")]
    public class CitiesController : ApiController
    {
        private CityManager _CityManager = new CityManager();

        // GET: api/Cities
        public IQueryable<City> Get()
        {
            return _CityManager.Get();
        }

        // GET: api/Citys/5
        //[ResponseType(typeof(City))]
        public IHttpActionResult Get(int id)
        {
            City city = _CityManager.GetById(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        //[ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Id)
            {
                return BadRequest();
            }

            try
            {
                _CityManager.Update(id, city);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_CityManager.CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cities
        //[ResponseType(typeof(City))]
        public IHttpActionResult Post([FromBody]City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _CityManager.Create(city);

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        //[ResponseType(typeof(City))]
        public IHttpActionResult Delete(int id)
        {
            _CityManager.Delete(id);

            return Ok();
        }

    }
}