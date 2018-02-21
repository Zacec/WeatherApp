using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WeatherApp.BL;
using WeatherApp.Model;

namespace WeatherApp.API.Controllers
{
    [AllowCors()]//[EnableCors(origins: "http://localhost:50916", headers: "*", methods: "*")]
    public class WeathersController : ApiController
    {
        private WeatherManager _WeatherManager = new WeatherManager();

        // GET: api/Weathers
        [ResponseType(typeof(Weather))]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_WeatherManager.Get());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Weathers/5
        [ResponseType(typeof(Weather))]
        [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Weather weather = _WeatherManager.GetById(id);
                if (weather == null)
                {
                    return NotFound();
                }

                return Ok(weather);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Weathers/5
        [ResponseType(typeof(Weather))]
        public IHttpActionResult Put(int id, [FromBody] Weather weather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weather.Id)
            {
                return BadRequest();
            }

            try
            {
                _WeatherManager.Update(id, weather);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_WeatherManager.WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Weathers
        [ResponseType(typeof(Weather))]
        public IHttpActionResult Post([FromBody]Weather weather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _WeatherManager.Create(weather);
                //TODO: ret created entity for validation
                //if ()
                //{
                //    return Conflict();
                //}
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Created<Weather>(Request.RequestUri + (new { id = weather.Id }).ToString(), weather);
        }

        // DELETE: api/Weathers/5
        //[ResponseType(typeof(Weather))]
        public IHttpActionResult Delete(int id)
        {
            _WeatherManager.Delete(id);

            return Ok();
        }
        
    }
}