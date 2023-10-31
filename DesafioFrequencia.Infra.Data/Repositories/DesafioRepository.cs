using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioFrequencia.Infra.Data.Repositories
{
    public class DesafioRepository : IDesafioRepository
    {
        private readonly DesafioFrequenciaContext _context;

        public DesafioRepository(DesafioFrequenciaContext context)
        {
            _context = context;
        }

        public async Task<Desafio> CreateAsync(Desafio desafio, CancellationToken cancellationToken)
        {
            await _context.Desafios.AddAsync(desafio, cancellationToken);
            return desafio;
        }

        public async Task<Desafio> GetByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return await _context.Desafios
                .Include(e => e.Participantes)
                .SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Desafio>> GetDesafioAsync(CancellationToken cancellationToken)
        {
            return await _context.Desafios.ToListAsync(cancellationToken);
        }

        public void Remove(Desafio desafio)
        {
            _context.Desafios.Remove(desafio);
        }

        public Desafio Update(Desafio desafio)
        {
            _context.Desafios.Update(desafio);
            return desafio;
        }
    }
}
