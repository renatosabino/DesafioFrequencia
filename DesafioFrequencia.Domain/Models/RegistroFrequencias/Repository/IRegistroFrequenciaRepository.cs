namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository
{
    public interface IRegistroFrequenciaRepository
    {
        Task<RegistroFrequencia> CreateAsync(RegistroFrequencia registroFrequencia, CancellationToken cancellationToken);
        void Remove(RegistroFrequencia registroFrequencia);
    }
}
