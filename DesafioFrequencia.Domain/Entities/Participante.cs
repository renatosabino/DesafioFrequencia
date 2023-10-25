using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.ValueObjects;

namespace DesafioFrequencia.Domain.Entities
{
    public sealed class Participante : Entity
    {
        public NomeCompleto NomeCompleto { get; private set; }
        public  Sexo Sexo { get; private set; }
        public DataDeNascimento DataDeNascimento { get; private set; }
        public Imagem? Imagem { get; private set; }

        private readonly IList<Desafio> _desafios;
        public IEnumerable<Desafio> Desafios => _desafios;

        public ICollection<RegistroFrequencia> RegistroFrequencias { get; }

        private Participante(int id, NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
        }

        public static Participante Registrar(int id, NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento)
        {
            DomainExceptionValidation.When(id < 0, "Id com valor inválido.");
            return new Participante(id, nomeCompleto, sexo, dataDeNascimento);
        }

        public void Editar(NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento)
        {
            NomeCompleto = nomeCompleto;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
        }

        public void AlterarImagem(Imagem imagem)
        {
            Imagem = imagem;
        }

        internal void AdicionarDesafio(Desafio desafio)
        {
            _desafios.Add(desafio);
        }
    }
}
