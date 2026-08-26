using Studio.Service.Dtos.RequestDto;
using Studio.Date;
using Studio.Domain.Models;
using Studio.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CriarAtendimento([FromBody] CriarAtendimentoRequestDto request)
        {
            var atendimento = new AtendimentoModels
            {
                CodigoCliente = request.CodigoCliente,
                CodigoAtendimento = request.PostoAtendimento,
                DataAtendimento = request.DataAtendimento,
                ValorTotal = request.ValorTotal
            };

            
            var pagamentoDto = request.Pagamentos?.FirstOrDefault();

            var resultado = await _atendimentoService.CriarAtendimento(
                atendimento,
                request.Procedimentos,
                pagamentoDto
            );

            return Ok(resultado);
        }
    }
}