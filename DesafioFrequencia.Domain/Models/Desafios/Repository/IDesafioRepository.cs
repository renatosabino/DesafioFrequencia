namespace DesafioFrequencia.Domain.Models.Desafios.Repository
{
    public interface IDesafioRepository
    {
        Task<IEnumerable<Desafio>> GetDesafioAsync(CancellationToken cancellationToken);
        Task<Desafio> GetByIdAsync(int? id, CancellationToken cancellationToken);

        Task<Desafio> CreateAsync(Desafio category, CancellationToken cancellationToken);
        Task<Desafio> UpdateAsync(Desafio category, CancellationToken cancellationToken);
        Task RemoveAsync(Desafio category, CancellationToken cancellationToken);
    }
}
