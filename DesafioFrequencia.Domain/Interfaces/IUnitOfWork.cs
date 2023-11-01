using DesafioFrequencia.Domain.Models.Desafios.Repository;
using DesafioFrequencia.Domain.Models.Participantes.Repository;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IParticipanteRepository ParticipanteRepository { get; }
        IDesafioRepository DesafioRepository { get; }
        IRegistroFrequenciaRepository RegistroFrequenciaRepository { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
