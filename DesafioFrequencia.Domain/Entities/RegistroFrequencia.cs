using DesafioFrequencia.Domain.ValueObjects;

namespace DesafioFrequencia.Domain.Entities
{
    public class RegistroFrequencia : Entity
    {
        public DataFrequencia DataFrequencia { get; set; }
        public Desafio Desafio { get; set; }
        public Participante Participante { get; set; }
        public Imagem Imagem { get; set; }
        public EstadoFrequencia EstadoFrequencia { get; private set; }

        private RegistroFrequencia(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem, EstadoFrequencia estadoFrequencia)
        {
            DataFrequencia = dataFrequencia;
            Desafio = desafio;
            Participante = participante;
            Imagem = imagem;
            EstadoFrequencia = estadoFrequencia;
        }

        //TODO: adicionar comportamentos
    }
}
