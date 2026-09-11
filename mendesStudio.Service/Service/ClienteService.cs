using Microsoft.EntityFrameworkCore;
using Studio.Date;
using Studio.Domain.Models;
using Studio.Service.Dtos.RequestDto;
using Studio.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio.Service.Service
{
    public class ClienteService : IClienteService
    {
        private readonly StudioAtendimentoContext _context;
        public ClienteService(StudioAtendimentoContext context)
        {
            _context = context;
        }
        public async Task<ClienteModels> CriarCliente(ClienteDto cliente)
        {
            var clienteModel = new ClienteModels
            {
                NomeCliente = cliente.NomeCliente,
                SexoCliente = cliente.SexoCliente,
                NomeSocial = cliente.NomeSocial,
                CpfCliente = cliente.CpfCliente,
                RgCliente = cliente.RgCliente
            };

            await _context.Clientes.AddAsync(clienteModel);
            await _context.SaveChangesAsync();
            return clienteModel;
        }

        public async Task<ClienteModels?> ObterClientePorCpf(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.CpfCliente == cpf);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return null;
            }
            return cliente;
        }

        public async Task<ClienteModels?> ObterClientePorId(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.CodigoCliente == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return null;
            }
            return cliente;
        }
    }
}
