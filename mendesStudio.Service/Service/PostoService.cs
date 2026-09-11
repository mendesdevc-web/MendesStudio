using Microsoft.EntityFrameworkCore;
using Studio.Date;
using Studio.Domain.Models;
using Studio.Service.Dtos.RequestDto;
using Studio.Service.Interface;


namespace Studio.Service.Service
{
    public class PostoService : IPostoService
    {
        private readonly StudioAtendimentoContext _context;
        public PostoService(StudioAtendimentoContext context)
        {
            _context = context;
        }
        public async Task<PostoModels> CriarPosto(PostoDto posto)
        {
            var postoModel = new PostoModels
            {
                DescPosto = posto.DescPosto,
                NomeEmpresa = posto.NomeEmpresa,
                ContaBancaria = posto.ContaBancaria
            };
            await _context.Postos.AddAsync(postoModel);
            await _context.SaveChangesAsync();

            return postoModel;
        }

        public async Task<PostoModels?> ObterPostoPorId(int id)
        {
            var posto = await _context.Postos.FirstOrDefaultAsync(p => p.CodigoPosto == id);
            
            return posto;
        }
    }
}
