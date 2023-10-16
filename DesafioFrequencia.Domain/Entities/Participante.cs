using DesafioFrequencia.Domain.ValueObjects;

namespace DesafioFrequencia.Domain.Entities
{
    public class Participante
    {
        public NomeCompleto NomeCompleto { get; private set; }
        public  Sexo Sexo { get; private set; }
        public DataDeNascimento DataDeNascimento { get; private set; }
        public Imagem Imagem { get; private set; }

        public Participante(NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento, Imagem imagem)
        {
            NomeCompleto = nomeCompleto;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
            Imagem = imagem;
        }
    }
}
