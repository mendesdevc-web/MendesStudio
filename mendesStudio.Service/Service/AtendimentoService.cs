using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Studio.Date;
using Studio.Domain.Models;
using Studio.Service.Dtos.RequestDto;
using Studio.Service.Interface;

namespace Studio.Service.Service
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly StudioAtendimentoContext _context;

        public AtendimentoService(StudioAtendimentoContext context)
        {
            _context = context;
        }

        public async Task<AtendimentoModels> CriarAtendimento(AtendimentoRequestDto atendimentoDto)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.CpfCliente == atendimentoDto.Cliente.CpfCliente);

            if (cliente == null)
            {
                cliente = new ClienteModels
                {
                    NomeCliente = atendimentoDto.Cliente.NomeCliente,
                    SexoCliente = atendimentoDto.Cliente.SexoCliente,
                    NomeSocial = atendimentoDto.Cliente.NomeSocial,
                    CpfCliente = atendimentoDto.Cliente.CpfCliente,
                    RgCliente = atendimentoDto.Cliente.RgCliente
                };
                await _context.Clientes.AddAsync(cliente);

                await _context.SaveChangesAsync();
            }
            else
            {
                cliente.NomeCliente = atendimentoDto.Cliente.NomeCliente;
                cliente.SexoCliente = atendimentoDto.Cliente.SexoCliente;
                cliente.NomeSocial = atendimentoDto.Cliente.NomeSocial;
                cliente.RgCliente = atendimentoDto.Cliente.RgCliente;
                _context.Clientes.Update(cliente);
            }

            var atendimento = new AtendimentoModels
            {
                CodigoCliente = cliente.CodigoCliente,
                DataAtendimento = DateTime.Now,
                CodigoPosto = atendimentoDto.PostoAtendimento
            };

            await _context.Atendimentos.AddAsync(atendimento);
            await _context.SaveChangesAsync(); 

            int idAtendimento = atendimento.CodigoAtendimento;

            var listaProcedimentos = atendimentoDto.Procedimentos.Select(p => new AtendimentoProcedimentoModels
            {
                CodigoAtendimento = idAtendimento,
                PostoAtendimento = atendimentoDto.PostoAtendimento,
                CodigoProcedimento = p.CodigoProcedimento
            }).ToList();

            if (listaProcedimentos.Any())
            {
                await _context.Atendimento_Procedimentos.AddRangeAsync(listaProcedimentos);
            }

            var listaPagamentoPix = atendimentoDto.Pagamentos
                .Where(p => p.Pix != null)
                .SelectMany(p => p.Pix)
                .Select(pixDto => new PagamentoPixModels
                {
                    CodigoAtendimento = idAtendimento,
                    PostoAtendimento = atendimentoDto.PostoAtendimento,
                    NomePagador = pixDto.NomePagador,
                    BancoPagador = pixDto.BancoPagador,
                    ValorPix = pixDto.ValorPix,
                    DataCriacao = DateTime.Now
                }).ToList();

            var listaPagamentoCartao = atendimentoDto.Pagamentos
                .Where(p => p.Cartao != null)
                .SelectMany(p => p.Cartao)
                .Select(cartaoDto => new PagamentosCartaoModels
                {
                    CodigoAtendimento = idAtendimento,
                    PostoAtendimento = atendimentoDto.PostoAtendimento,
                    NomeCartao = cartaoDto.NomeCartao,
                    NumeroCartao = cartaoDto.NumeroCartao,
                    ValorCartao = cartaoDto.ValorCartao,
                    BandeiraCartao = cartaoDto.BandeiraCartao,
                    DataCriacao = DateTime.Now,
                    NumeroVezes = cartaoDto.NumeroVezes,
                    DebitoCredito = cartaoDto.DebitoCredito
                }).ToList();

            var listaPagamentoDinheiro = atendimentoDto.Pagamentos
                .Where(p => p.Dinheiro != null)
                .SelectMany(p => p.Dinheiro)
                .Select(dinheiroDto => new PagamentosDinheiroModels
                {
                    CodigoAtendimento = idAtendimento,
                    PostoAtendimento = atendimentoDto.PostoAtendimento,
                    NomePagador = dinheiroDto.NomePagador,
                    CpfPagador = dinheiroDto.CpfPagador,
                    ValorDinheiro = dinheiroDto.ValorDinheiro,
                    DataCriacao = DateTime.Now
                }).ToList();

            if (listaPagamentoPix.Any())
                await _context.Pagamentos_Pix.AddRangeAsync(listaPagamentoPix);

            if (listaPagamentoCartao.Any())
                await _context.Pagamentos_Cartao.AddRangeAsync(listaPagamentoCartao);

            if (listaPagamentoDinheiro.Any())
                await _context.Pagamentos_Dinheiro.AddRangeAsync(listaPagamentoDinheiro);

            try
            {

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error saving atendimento: {ex.Message}");
                throw; 
            }

            return atendimento;
        }
    }
}