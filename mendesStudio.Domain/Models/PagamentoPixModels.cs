using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Models
{
    public class PagamentoPixModels
    {
        public int CodigoAtendimento { get; set; }
        public int CodPagamentoPix { get; set; }
        public string NomePagador { get; set; }
        public string BancoPagador { get; set; }
        public decimal ValorPix { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaModificacao { get; set; }
    }
}
