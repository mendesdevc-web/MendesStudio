using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.Domain.Models
{
    [NotMapped]
    public class PagamentoModels
    {
        public int CodigoPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public string TipoPagamento { get; set; } = string.Empty;
        public int CodigoAtendimento { get; set; }
        public AtendimentoModels Atendimento { get; set; } = null!;

        // Listas de formas de pagamento vinculadas a ESTE pagamento
        public ICollection<PagamentoPixModels> Pix { get; set; } = new List<PagamentoPixModels>();
        public ICollection<PagamentosCartaoModels> Cartao { get; set; } = new List<PagamentosCartaoModels>();
        public ICollection<PagamentosDinheiroModels> Dinheiro { get; set; } = new List<PagamentosDinheiroModels>();
    }
}
