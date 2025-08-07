using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Views.comanda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBackEndApi.Src.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/comandas")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaAppService _comandaAppService;

        public ComandaController(IComandaAppService comandaAppService)
        {
            _comandaAppService = comandaAppService;
        }

        [HttpGet]
        [Authorize]
        [EndpointSummary("Pega a lista de todas as comandas, mas sem a informação do produto")]
        public async Task<ActionResult<List<ComandaUsuarioView>>> ListarTodasComandas()
        {
            var usuarios = await _comandaAppService.ListarUsuariosDasComandas();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        [EndpointSummary("Pega a comanda por completo com base no id")]
        public async Task<ActionResult<ComandaCompletaView>> BuscarPorId(int id)
        {
            var comanda = await _comandaAppService.BuscarComandaCompleta(id);

            if (comanda == null)
                return NotFound();

            return Ok(comanda);
        }

        [HttpPost]
        [Authorize]
        [EndpointSummary("Cria a comanda e os produtos (caso não exista o produto)")]
        public async Task<ActionResult<ComandaCriadaView>> Criar([FromBody] ComandaCompletaView view)
        {
            var criada = await _comandaAppService.CriarComanda(view);
            return CreatedAtAction(nameof(BuscarPorId), new { id = criada.Id }, criada);
        }

        [HttpPut("{id}")]
        [Authorize]
        [EndpointSummary("Atualiza os produtos da comanda com base no id")]
        public async Task<IActionResult> AtualizarComanda(int id, [FromBody] ComandaUpdateView view)
        {
            await _comandaAppService.AtualizarComanda(id, view);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [EndpointSummary("Remove a comanda com base no id")]
        public async Task<IActionResult> RemoverComanda(int id)
        {
            await _comandaAppService.RemoverComanda(id);

            return Ok(new
            {
                success = new
                {
                    text = "comanda removida"
                }
            });
        }
    }
}
