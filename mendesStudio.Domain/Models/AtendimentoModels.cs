using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Models
{
    public class AtendimentoModels
    {
        public int CodigoAtendimento { get; set; } 
        public int CodigoPosto { get; set; }
        public int CodigoCliente { get; set; }
        public DateTime DataAtendimento { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
