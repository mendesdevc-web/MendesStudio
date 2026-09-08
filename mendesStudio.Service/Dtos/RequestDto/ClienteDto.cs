using Studio.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Dtos.RequestDto
{
    public class ClienteDto
    {
        public string NomeCliente { get; set; }
        public TipoSexoEnum SexoCliente { get; set; }
        public string? NomeSocial { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CpfCliente { get; set; }
        public string RgCliente { get; set; }
    }
}
