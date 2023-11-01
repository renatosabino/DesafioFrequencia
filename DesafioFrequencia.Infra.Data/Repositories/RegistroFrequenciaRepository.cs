using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository;
using DesafioFrequencia.Infra.Data.Context;

namespace DesafioFrequencia.Infra.Data.Repositories
{
    public class RegistroFrequenciaRepository : IRegistroFrequenciaRepository
    {
        private readonly DesafioFrequenciaContext _context;

        public RegistroFrequenciaRepository(DesafioFrequenciaContext context)
        {
            _context = context;
        }

        public async Task<RegistroFrequencia> CreateAsync(RegistroFrequencia registroFrequencia, CancellationToken cancellationToken)
        {
            await _context.RegistroFrequencias.AddAsync(registroFrequencia);
            return registroFrequencia;
        }

        public void Remove(RegistroFrequencia registroFrequencia)
        {
            _context.RegistroFrequencias.Remove(registroFrequencia);
        }
    }
}
