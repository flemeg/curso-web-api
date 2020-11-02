using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeuWebApi.Controllers
{

    [Route("api/[controller]")]
    public class WeatherForecastController : MainController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromForm] string product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("find/{param}")]
        public ActionResult<string> GetSummary(string param)
        {
            var found = Summaries.Where(s => s.Equals(param)).FirstOrDefault();
            if (found == null)
            {
                return BadRequest();
            }

            return Ok(found);
        }

        [HttpPost]
        [Route("savenew")]
        [ProducesResponseType(200)]
        public ActionResult PostSaveNew([FromForm] string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
