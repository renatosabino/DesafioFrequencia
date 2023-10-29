namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.Repository
{
    public interface IRegistroFrequenciaRepository
    {
        Task<RegistroFrequencia> CreateAsync(RegistroFrequencia registroFrequencia);
        Task RemoveAsync(RegistroFrequencia registroFrequencia);
    }
}
