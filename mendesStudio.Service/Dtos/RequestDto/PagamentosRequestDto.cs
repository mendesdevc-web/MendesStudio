using System.Collections.Generic;
using Studio.Domain.Models; 

namespace Studio.Service.Dtos.RequestDto
{
    public class PagamentosRequestDto
    {
        public int CodigoAtendimento { get; set; }
        public int PostoAtendimento { get; set; }
        public List<PagamentoPixModels> Pix { get; set; }
        public List<PagamentosCartaoModels> Cartao { get; set; }
        public List<PagamentosDinheiroModels> Dinheiro { get; set; }
    }
}