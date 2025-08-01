using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Objects;
using Microsoft.AspNetCore.Mvc;

namespace MeuBackEndApi.Src.Controllers
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
        private readonly IMensagemService _mensagemService;

        public MensagemController(IMensagemService mensagemService)
        {
            _mensagemService = mensagemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { mensagem = "Olá do back-end em C#" });
        }

        [HttpPost("getMensagem")]
        public string GetMesagem([FromBody] string nome)
        {
            return _mensagemService.GetMensagem(nome);
        }

        [HttpPost("getObjeto")]
        public Pessoa GetObjeto([FromBody] string nome)
        {
            return _mensagemService.GetObjeto(nome);
        }
    }
}
