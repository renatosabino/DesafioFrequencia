namespace DesafioFrequencia.Domain.Models.Desafios.Repository
{
    public interface IDesafioRepository
    {
        Task<IEnumerable<Desafio>> GetDesafioAsync(CancellationToken cancellationToken);
        Task<Desafio> GetByIdAsync(int? id, CancellationToken cancellationToken);

        Task<Desafio> CreateAsync(Desafio desafio, CancellationToken cancellationToken);
        Desafio Update(Desafio desafio);
        void Remove(Desafio desafio);
    }
}
