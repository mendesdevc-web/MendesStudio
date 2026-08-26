using Studio.Service.Dtos.RequestDto;
using Studio.Date;
using Studio.Domain.Models;
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
        public async Task<AtendimentoModels> CriarAtendimento(AtendimentoModels atendimento,
                                                List<ProcedimentosRequestDto> procedimentos,PagamentosRequestDto pagamento)
        {
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();

            if (procedimentos != null && procedimentos.Any())
            {
                foreach (var item in procedimentos)
                {
                    _context.Atendimento_Procedimentos.Add(new AtendimentoProcedimentoModels
                    {
                        CodigoAtendimento = atendimento.CodigoAtendimento,
                        PostoAtendimento = atendimento.CodigoPosto,
                        CodigoProcedimento = item.CodigoProcedimento,
                    });
                }
            }

            if (pagamento != null)
            {
                if (pagamento.Pix != null && pagamento.Pix.Any())
                {
                    foreach (var pix in pagamento.Pix)
                    {
                        pix.CodigoAtendimento = atendimento.CodigoAtendimento;
                        _context.Pagamentos_Pix.Add(pix);
                    }
                }

                if (pagamento.Cartao != null && pagamento.Cartao.Any())
                {
                    foreach (var cartao in pagamento.Cartao)
                    {
                        cartao.CodigoAtendimento = atendimento.CodigoAtendimento;
                        _context.Pagamentos_Cartao.Add(cartao);
                    }
                }

                if (pagamento.Dinheiro != null && pagamento.Dinheiro.Any())
                {
                    foreach (var dinheiro in pagamento.Dinheiro)
                    {
                        dinheiro.CodigoAtendimento = atendimento.CodigoAtendimento;
                        _context.Pagamentos_Dinheiro.Add(dinheiro);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return atendimento;
        }
    }
}