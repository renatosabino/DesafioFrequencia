namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository
{
    public interface IRegistroFrequenciaRepository
    {
        Task<RegistroFrequencia> CreateAsync(RegistroFrequencia registroFrequencia, CancellationToken cancellationToken);
        Task RemoveAsync(RegistroFrequencia registroFrequencia, CancellationToken cancellationToken);
    }
}
