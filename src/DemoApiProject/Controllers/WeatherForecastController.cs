using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoApiProject.Controllers
{
    /// <summary>
    /// Sample API created by Microsoft and included in the project
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")] //Notify that we are expecting/sending JSON
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets a random weather forecast
        /// </summary>
        /// <remarks>
        /// Does not provide any real value
        ///
        /// Sample Request:
        /// 
        ///     GET /WeatherForecast
        /// </remarks>
        /// <returns>
        /// Detailed random weather forecast based on a random summary and temperature
        /// </returns>
        /// <response code="200">Returns the random weather forecast</response>
        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
