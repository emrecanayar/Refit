using Microsoft.AspNetCore.Mvc;
using RefitExample.Abstractions;
using RefitExample.Models;

namespace RefitExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPostsClient _postsClient;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPostsClient postsClient)
        {
            _logger = logger;
            _postsClient = postsClient;
        }

        //Oluþturduðumuz yapýnýn testini gerçekleþtirmek için oluþturduðumuz action metot.

        [HttpGet("GetPostById", Name = "GetPostById")]
        [ProducesResponseType(typeof(PostDto), 200)]
        [Produces("application/json")]
        public async Task<PostDto> GetPostById(int postId)
        {
            var response = await _postsClient.GetPostById(postId);
            return response;
        }



        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }


}