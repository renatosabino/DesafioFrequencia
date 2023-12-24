using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository;
using System.Security.Claims;

namespace DesafioFrequencia.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IParticipanteRepository ParticipanteRepository { get; }
        IDesafioRepository DesafioRepository { get; }
        IRegistroFrequenciaRepository RegistroFrequenciaRepository { get; }
        string? EmailLogado { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
