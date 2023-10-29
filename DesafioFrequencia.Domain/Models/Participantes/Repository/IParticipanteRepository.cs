namespace DesafioFrequencia.Domain.Models.Participantes.Repository
{
    public interface IParticipanteRepository
    {
        Task<IEnumerable<Participante>> GetParticipanteAsync();
        Task<Participante> GetByIdAsync(int? id);

        Task<Participante> CreateAsync(Participante category);
        Task<Participante> UpdateAsync(Participante category);
        Task RemoveAsync(Participante category);
    }
}
