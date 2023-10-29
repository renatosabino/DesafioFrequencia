namespace DesafioFrequencia.Domain.Models.Participantes.Repository
{
    public interface IParticipanteRepository
    {
        Task<IEnumerable<Participante>> GetParticipanteAsync(CancellationToken cancellationToken);
        Task<Participante> GetByIdAsync(int? id, CancellationToken cancellationToken);

        Task<Participante> CreateAsync(Participante participante, CancellationToken cancellationToken);
        Participante Update(Participante participante);
        void Remove(Participante participante);
    }
}
