using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFrequencia.Domain.ValueObjects
{
    public class Imagem
    {
        public string Endereco { get; private set; }

        public Imagem(string endereco)
        {
            this.Endereco = endereco;
        }
    }
}
