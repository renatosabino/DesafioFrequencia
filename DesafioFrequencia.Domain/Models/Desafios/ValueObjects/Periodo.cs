using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Models.Desafios.ValueObjects
{
    public struct Periodo
    {
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }

        public Periodo(DateTime inicio, DateTime fim)
        {
            DomainExceptionValidation.When(inicio > fim, "O fim não pode ser menor que o inicio.");
            Inicio = inicio;
            Fim = fim;
        }
    }
}
