using Studio.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Dtos.RequestDto
{
    public class PagamentoCartaoDto
    {
        public int CodPagamentoCartao { get; set; }
        public int CodigoAtendimento { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public decimal ValorCartao { get; set; }
        public string BandeiraCartao { get; set; }
       // public DateTime DataCriacao { get; set; }
       // public DateTime DataUltimaModificacao { get; set; }
        public int NumeroVezes { get; set; }
        public TipoCartaoEnum DebitoCredito { get; set; }
    }
}
