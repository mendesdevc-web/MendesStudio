using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Models
{
    public class PostoModels
    {
        public int CodigoPosto { get; set; }
        public string DescPosto { get; set; }
        public string NomeEmpresa { get; set; }
        public string ContaBancaria { get; set; }
        

        public ICollection<AtendimentoModels> Atendimentos { get; set; }
    }
}
