using Studio.Date;
using Studio.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Studio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly StudioAtendimentoContext _context;

        public ClienteController(StudioAtendimentoContext context)
        {
            _context = context;
        }

        [HttpGet("teste-conexao")]
        public async Task<IActionResult> TestarConexao()
        {
            var conectado = await _context.Database.CanConnectAsync();

            if (conectado)
            {
                return Ok("Conexão com o banco realizada com sucesso!");
            }

            return StatusCode(500, "Não foi possível conectar ao banco.");
        }

        [HttpGet("teste-leitura")]
        public async Task<IActionResult> TestarLeitura()
        {
            var clientes = await _context.Clientes.ToListAsync();

            return Ok(clientes);
        }

        [HttpPost("teste-insert-cliente")]
        public async Task<IActionResult> TestarInsertCliente(
            [FromBody] ClienteModels cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPost("teste-insert-posto")]
        public async Task<IActionResult> TestarInsertPosto(
            [FromBody] PostoModels posto)
        {
            _context.Postos.Add(posto);

            await _context.SaveChangesAsync();

            return Ok(posto);
        }

        [HttpPost("teste-insert-procedimento")]
        public async Task<IActionResult> TestarInsertProcedimento(
            [FromBody] ProcedimentoModels procedimento)
        {
            _context.Procedimentos.Add(procedimento);

            await _context.SaveChangesAsync();

            return Ok(procedimento);
        }

        [HttpPost("teste-insert-pix")]
        public async Task<IActionResult> TestarInsertPix(
            [FromBody] PagamentoPixModels pix)
        {
            _context.Pagamentos_Pix.Add(pix);

            await _context.SaveChangesAsync();

            return Ok(pix);
        }

        [HttpPost("teste-insert-cartao")]
        public async Task<IActionResult> TestarInsertCartao(
            [FromBody] PagamentosCartaoModels cartao)
        {
            _context.Pagamentos_Cartao.Add(cartao);

            await _context.SaveChangesAsync();

            return Ok(cartao);
        }

        [HttpPost("teste-insert-dinheiro")]
        public async Task<IActionResult> TestarInsertDinheiro(
            [FromBody] PagamentosDinheiroModels dinheiro)
        {
            _context.Pagamentos_Dinheiro.Add(dinheiro);

            await _context.SaveChangesAsync();

            return Ok(dinheiro);
        }
    }
}