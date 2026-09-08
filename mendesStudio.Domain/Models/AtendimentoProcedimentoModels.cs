using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Models
{
    public class AtendimentoProcedimentoModels
    {
        public int CodigoAtendimento { get; set; }
        public int CodigoProcedimento { get; set; }
        public int PostoAtendimento { get; set; }

        public AtendimentoModels Atendimento { get; set; }
        public ProcedimentoModels Procedimento { get; set; }
    }
}
