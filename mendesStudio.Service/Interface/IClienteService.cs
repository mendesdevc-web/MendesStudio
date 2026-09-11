using Studio.Domain.Models;
using Studio.Service.Dtos.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Interface
{
    public interface IClienteService
    {
        Task<ClienteModels> CriarCliente(ClienteDto cliente);
        Task<ClienteModels?> ObterClientePorId(int id);
        Task<ClienteModels?> ObterClientePorCpf(string cpf);
    }
}
