using Studio.Service.Dtos.RequestDto;
using Studio.Date;
using Studio.Service.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Studio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly StudioAtendimentoContext _context;
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentoController(StudioAtendimentoContext context, IAtendimentoService atendimentoService)
        {
            _context = context;
            _atendimentoService = atendimentoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAtendimento([FromBody] AtendimentoDto request)
        {
            if (request == null)
            {
                return BadRequest("Os dados do atendimento não foram fornecidos.");
            }

            var resultado = await _atendimentoService.CriarAtendimento(request);

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterAtendimentoPorId(int id)
        {
            var atendimento = await _atendimentoService.ObterAtendimentoPorId(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return Ok(atendimento);
        }
    }
}