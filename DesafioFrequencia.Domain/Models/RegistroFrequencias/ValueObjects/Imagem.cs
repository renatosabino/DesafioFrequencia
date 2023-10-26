using DesafioFrequencia.Domain.Exceptions;

namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects
{
    public struct Imagem
    {
        public string Endereco { get; private set; }

        public Imagem(string endereco)
        {
            DomainExceptionValidation.When(endereco.Length > 100, "O nome da imagem ultrapassou os caracteres suportados.");
            Endereco = endereco;
        }
    }
}
