using System;
using System.Collections.Generic;

namespace Studio.Service.Dtos.RequestDto 
{
    public class CriarAtendimentoRequestDto
    {
        public int CodigoCliente { get; set; }
        public int PostoAtendimento { get; set; }
        public DateTime DataAtendimento { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ProcedimentosRequestDto> Procedimentos { get; set; }
        public List<PagamentosRequestDto> Pagamentos { get; set; }
    }
}