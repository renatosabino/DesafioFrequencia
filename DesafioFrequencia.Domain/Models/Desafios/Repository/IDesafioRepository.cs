namespace DesafioFrequencia.Domain.Models.Desafios.Repository
{
    public interface IDesafioRepository
    {
        Task<IEnumerable<Desafio>> GetDesafioAsync();
        Task<Desafio> GetByIdAsync(int? id);

        Task<Desafio> CreateAsync(Desafio category);
        Task<Desafio> UpdateAsync(Desafio category);
        Task RemoveAsync(Desafio category);
    }
}
