using Studio.Date;
using Studio.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studio.Service.Service;

namespace Studio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly StudioAtendimentoContext _context;
        private readonly ClienteService _clienteService;

        public ClienteController(StudioAtendimentoContext context, ClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterClienteId(int id)
        {
            var cliente = await _clienteService.ObterClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> ObterClienteCpf(string cpf)
        {
            var cliente = await _clienteService.ObterClientePorCpf(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
    }
}