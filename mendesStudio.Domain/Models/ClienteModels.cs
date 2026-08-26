using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Models
{
    public class ClienteModels
    {
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string SexoCliente { get; set; }
        public string? NomeSocial { get; set; }
        public string CpfCliente { get; set; }
        public string RgCliente { get; set; }
    }
}
