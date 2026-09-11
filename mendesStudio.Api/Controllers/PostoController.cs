using Microsoft.AspNetCore.Mvc;
using Studio.Date;
using Studio.Service.Dtos.RequestDto;
using Studio.Service.Service;

namespace Studio.Api.Controllers
{
    public class PostoController : Controller
    {
        private readonly StudioAtendimentoContext _context;
        private readonly PostoService _postoService;
        public PostoController(StudioAtendimentoContext context, PostoService postoService)
        {
            _context = context;
            _postoService = postoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPostoId(int id)
        {
            var posto = await _postoService.ObterPostoPorId(id);
            if (posto == null)
            {
                return NotFound();
            }
            return Ok(posto);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPosto([FromBody] PostoDto request)
        {
            var posto = await _postoService.CriarPosto(request);
            if (posto == null)
            {
                return NotFound();
            }
            return Ok(posto);
            
        }
    }
}
