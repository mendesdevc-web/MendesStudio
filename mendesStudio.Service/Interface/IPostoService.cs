using Studio.Domain.Models;
using Studio.Service.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Interface
{
    public interface IPostoService
    {
        Task<PostoModels> CriarPosto(PostoDto posto);
        Task<PostoModels?> ObterPostoPorId(int id);
    }
}
