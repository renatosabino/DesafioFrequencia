using DesafioFrequencia.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace DesafioFrequencia.Domain.Models.Participantes.ValueObjects
{
    public class Email
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            DomainExceptionValidation.When(!EhValido(endereco), "O email é inválido.");            
            Endereco = endereco;
        }

        public bool EhValido(string email)
        {
            return Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9\-\.]+)\.([a-zA-Z]{2,6})$");
        }
    }
}
