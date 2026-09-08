using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Dtos.RequestDto
{
    public class ProcedimentosRequestDto
    {
        public int CodigoProcedimento { get; set; }
        public string Desc_Procedimento { get; set; }
        public decimal Valor { get; set; }
    }
}