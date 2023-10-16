using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Domain.ValueObjects
{
    public class NomeCompleto
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }
}
