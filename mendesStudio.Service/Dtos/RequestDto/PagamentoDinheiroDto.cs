using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Dtos.RequestDto
{
    public class PagamentoDinheiroDto
    {
        public int CodPagamentoDinheiro { get; set; }
        public int CodigoAtendimento { get; set; }
        public int PostoAtendimento { get; set; }
        public string NomePagador { get; set; }
        public string CpfPagador { get; set; }
        public decimal ValorDinheiro { get; set; }
       // public DateTime DataCriacao { get; set; }
       // public DateTime DataUltimaModificacao { get; set; }
    }
}
