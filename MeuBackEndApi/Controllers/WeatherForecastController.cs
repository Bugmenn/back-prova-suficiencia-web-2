using Microsoft.AspNetCore.Mvc;

namespace MeuBackEndApi.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet(Name = "GetWeatherForecast")]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //            TemperatureC = Random.Shared.Next(-20, 55),
    //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}

    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/mensagem")]
    public class MensagemController : ControllerBase
    {
        public class Pessoa
        {
            public string Nome { get; set; }
            public string Data { get; set; }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { mensagem = "Olá do back-end em C#" });
        }

        [HttpPost("getMensagem")]
        public string GetMesagem([FromBody] string nome)
        {
            return $"Olá, {nome} do back-end em C#";
        }

        [HttpPost("getObjeto")]
        public Pessoa GetObjeto([FromBody] string nome)
        {
            return new Pessoa
            {
                Nome = $"Olá {nome}",
                Data = DateTime.Now.ToString("dd/MM/yyyy")
            };
        }
    }
}
