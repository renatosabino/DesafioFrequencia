using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Models.Participantes.ValueObjects
{
    public struct NomeCompleto
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomeCompleto(string nome, string sobrenome)
        {
            DomainExceptionValidation.When(nome.Length > 50, "O Nome ultrapassou a quantidade de caracteres suportados.");
            DomainExceptionValidation.When(sobrenome.Length > 100, "O Sobrenome ultrapassou a quantidade de caracteres suportados.");
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }
}
