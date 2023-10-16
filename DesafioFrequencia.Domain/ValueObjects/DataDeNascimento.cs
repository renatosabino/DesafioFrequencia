using DesafioFrequencia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Domain.ValueObjects
{
    public class DataDeNascimento
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
