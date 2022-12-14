using IronPdf;
using Microsoft.AspNetCore.Mvc;

namespace TestWebAppWithReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            string? ironError = null;
            try
            {
                var pdf = new ChromePdfRenderer();
                var doc = pdf.RenderHtmlAsPdf("<h1>This is a heading</h1>");
            }
            catch (Exception e)
            {
                ironError = e.ToString();
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                IronError = ironError
            })
            .ToArray();
        }
    }
}