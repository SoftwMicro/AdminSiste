using AdminSiste.Models;
using AdminSiste.Data;
using Microsoft.EntityFrameworkCore;

namespace AdminSiste.Services.Servico
{
    public class ServicoService
    {
        private readonly AppDbContext _context;
        public ServicoService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Models.Servico.Servico>> ListarTodosAsync()
        {
            return await _context.Servicos
                .Include(s => s.Atividade)
                .Include(s => s.Impostos)
                .ToListAsync();
        }


        public async Task<Models.Servico.Servico?> ObterPorIdAsync(int id)
        {
            return await _context.Servicos
                .Include(s => s.Atividade)
                .Include(s => s.Impostos)
                .FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task AdicionarAsync(Models.Servico.Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();
        }


        public async Task AtualizarAsync(Models.Servico.Servico servico)
        {
            _context.Servicos.Update(servico);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var servico = await ObterPorIdAsync(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
