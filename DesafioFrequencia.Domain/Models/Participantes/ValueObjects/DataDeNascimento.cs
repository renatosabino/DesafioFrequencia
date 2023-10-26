using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Models.Participantes.ValueObjects
{
    public struct DataDeNascimento
    {
        public DateTime Valor { get; private set; }

        public DataDeNascimento(DateTime valor)
        {
            DomainExceptionValidation.When(valor >= DateTime.Now.Date,
                "A data de nascimento não pode ser maior ou igual a data atual.");

            Valor = valor;
        }
    }
}
