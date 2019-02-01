using System;
using System.Linq;
using System.Threading.Tasks;
using ApiFiltroGeral.Models.Inputs;
using ApiFiltroGeral.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ApiFiltroGeral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaController : ControllerBase
    {
        private readonly UfServico _servico = new UfServico();

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _servico.SelecionarAsync();

                if (result.Count() == 0)
                    return NotFound("Nenhum objeto registrado");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro no servidor");
            }
        }

        [HttpGet]
        [Route("Filtro")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPorFiltro([FromQuery] FiltroInput obj)
        {
            try
            {
                var result = await _servico.SelecionarPorFiltroAsync(obj);

                if (!result.Any())
                    return BadRequest("Nenhum objeto encontrado");

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro no servidor");
            }
        }
    }
}