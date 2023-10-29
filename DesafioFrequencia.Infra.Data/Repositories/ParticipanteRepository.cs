using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Infra.Data.Repositories
{
    public sealed class ParticipanteRepository : IParticipanteRepository
    {
        private readonly DesafioFrequenciaContext _context;

        public ParticipanteRepository(DesafioFrequenciaContext context)
        {
            _context = context;
        }

        public async Task<Participante> CreateAsync(Participante participante, CancellationToken cancellationToken)
        {
            await _context.Participantes.AddAsync(participante, cancellationToken);
            return participante;
        }

        public async Task<Participante> GetByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return await _context.Participantes
                .Include(e => e.Desafios)
                .Include(e => e.RegistroFrequencias)
                .SingleOrDefaultAsync(f => f.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Participante>> GetParticipanteAsync(CancellationToken cancellationToken)
        {
            return await _context.Participantes.ToListAsync(cancellationToken);
        }

        public void Remove(Participante participante)
        {
            _context.Participantes.Remove(participante);
        }

        public Participante Update(Participante participante)
        {
            _context.Participantes.Update(participante);
            return participante;
        }
    }
}
