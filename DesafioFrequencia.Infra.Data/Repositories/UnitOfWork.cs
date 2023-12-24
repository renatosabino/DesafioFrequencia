using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository;
using DesafioFrequencia.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DesafioFrequencia.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DesafioFrequenciaContext _context;

        private IHttpContextAccessor _httpContextAccessor;

        public IParticipanteRepository ParticipanteRepository { get; }

        public IDesafioRepository DesafioRepository { get; }

        public IRegistroFrequenciaRepository RegistroFrequenciaRepository { get; }

        public string? EmailLogado => _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

        public UnitOfWork(DesafioFrequenciaContext context,
            IParticipanteRepository participanteRepository,
            IDesafioRepository desafioRepository,
            IRegistroFrequenciaRepository registroFrequenciaRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ParticipanteRepository = participanteRepository ?? throw new ArgumentNullException(nameof(participanteRepository));
            DesafioRepository = desafioRepository ?? throw new ArgumentNullException(nameof(desafioRepository));
            RegistroFrequenciaRepository = registroFrequenciaRepository ?? throw new ArgumentNullException(nameof(registroFrequenciaRepository));
            _httpContextAccessor = httpContextAccessor;
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
