using System;
using System.Collections.Generic;

namespace Studio.Service.Dtos.RequestDto 
{
    public class AtendimentoRequestDto
    {
        public int PostoAtendimento { get; set; }
        // public DateTime DataAtendimento { get; set; }
        public ClienteDto Cliente { get; set; }
        public List<ProcedimentosRequestDto> Procedimentos { get; set; }
        public List<PagamentosRequestDto> Pagamentos { get; set; }
    }
}