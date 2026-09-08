using System.Collections.Generic;
using Studio.Domain.Models;

namespace Studio.Service.Dtos.RequestDto
{
    public class PagamentosRequestDto
    {
        public int CodigoAtendimento { get; set; }
        public int PostoAtendimento { get; set; }
        public List<PagamentoPixDto> Pix { get; set; }
        public List<PagamentoCartaoDto> Cartao { get; set; }
        public List<PagamentoDinheiroDto> Dinheiro { get; set; }
        public decimal valorTotal { get; set; }
    }
}