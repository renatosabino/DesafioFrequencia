using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository;
using DesafioFrequencia.Infra.Data.Context;

namespace DesafioFrequencia.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioFrequenciaContext _context;

        public IParticipanteRepository ParticipanteRepository { get; }

        //public IDesafioRepository DesafioRepository { get; }

        //public IRegistroFrequenciaRepository RegistroFrequenciaRepository { get; }

        public UnitOfWork(DesafioFrequenciaContext context,
            IParticipanteRepository participanteRepository/*,
            IDesafioRepository desafioRepository,
            IRegistroFrequenciaRepository registroFrequenciaRepository*/)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ParticipanteRepository = participanteRepository ?? throw new ArgumentNullException(nameof(participanteRepository));
            //DesafioRepository = desafioRepository ?? throw new ArgumentNullException(nameof(desafioRepository));
            //RegistroFrequenciaRepository = registroFrequenciaRepository ?? throw new ArgumentNullException(nameof(registroFrequenciaRepository));
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
