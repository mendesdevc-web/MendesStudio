using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Domain.Enum
{
    public enum TipoCartaoEnum
    {
        [Display(Name = "Débito")]
        D = 1,

        [Display(Name = "Crédito")]
        C = 2,
    }
}
