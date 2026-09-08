using System.Collections.Generic;
using System.Threading.Tasks;
using Studio.Service.Dtos.RequestDto;
using Studio.Domain.Models;

namespace Studio.Service.Interface
{
    public interface IAtendimentoService
    {
        Task<AtendimentoModels> CriarAtendimento( AtendimentoRequestDto atendimento);
    }
}