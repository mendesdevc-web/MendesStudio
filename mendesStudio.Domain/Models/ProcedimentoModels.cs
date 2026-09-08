using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Models
{
    public class ProcedimentoModels
    {
        public int CodigoProcedimento { get; set; }
        public string DescProcedimento { get; set; }

        public ICollection<AtendimentoModels> Atendimentos { get; set; }
        public ICollection<AtendimentoProcedimentoModels> AtendimentoProcedimentos { get; set; }
    }
}
