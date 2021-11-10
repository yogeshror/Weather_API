using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Weather_API.Model;
using Weather_API.Models;

namespace Weather_API.Controllers
{
    //API controller for weather
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly Weather_Web_APIDataContext _context;

        public WeathersController(Weather_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/Weathers
        //Get all weather records using a linq query
        [HttpGet]
        public ActionResult<IEnumerable<Weather>> GetWeather()
        {
            return (from weather in _context.Weather select weather).ToList();
        }

        // GET: api/Weathers/5
        //Gets a weather record using  a linq query
        [HttpGet("{id}")]
        public ActionResult<Weather> GetWeather(int id)
        {
            var weather = (from weatherRec in _context.Weather
                           where weatherRec.Id == id
                           select weatherRec).FirstOrDefault();

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weathers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates a weather record 
        [HttpPut("{id}")]
        public IActionResult PutWeather(int id, Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weathers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds a weaher record to database.
        [HttpPost]
        public ActionResult<Weather> PostWeather(Weather weather)
        {
            _context.Weather.Add(weather);
            _context.SaveChanges();

            return CreatedAtAction("GetWeather", new { id = weather.Id }, weather);
        }

        // DELETE: api/Weathers/5
        //Removes a weather record uses a linq query to  select the record.
        [HttpDelete("{id}")]
        public ActionResult<Weather> DeleteWeather(int id)
        {
            var weather = (from weatherRec in _context.Weather
                           where weatherRec.Id == id
                           select weatherRec).FirstOrDefault();
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weather.Remove(weather);
            _context.SaveChanges();

            return weather;
        }

        //Checks the weather record exixts using a lamda query.
        private bool WeatherExists(int id)
        {
            return _context.Weather.Any(e => e.Id == id);
        }
    }
}
