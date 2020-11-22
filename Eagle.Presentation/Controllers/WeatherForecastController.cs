using System;
using Eagle.Common.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Eagle.Presentation.Controllers
{
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStringLocalizer<Resources.Resources> _localizer;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<Resources.Resources> localizer): base(localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();

            if (rng == null)
            {
                throw CustomExceptions.RecordNotFound;
            }

            var localizedMessage = _localizer["Success"];

            return Ok(new ResponseModel(true, localizedMessage));
        }
    }
}
