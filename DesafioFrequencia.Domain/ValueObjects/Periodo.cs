using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.ValueObjects
{
    public struct Periodo
    {
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }

        public Periodo(DateTime inicio, DateTime fim)
        {
            DomainExceptionValidation.When(fim > inicio, "O fim não pode ser menor que o inicio.");
            Inicio = inicio;
            Fim = fim;
        }
    }
}
