using DesafioFrequencia.Domain.Models.Participantes.ValueObjects;
using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.Models.RegistroFrequencias;
using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.BuildingBlocks.Domain;

namespace DesafioFrequencia.Domain.Models.Participantes
{
    public class Participante : Entity, IAggregateRoot
    {
        public NomeCompleto NomeCompleto { get; private set; }
        public Sexo Sexo { get; private set; }
        public DataDeNascimento DataDeNascimento { get; private set; }
        public Imagem? Imagem { get; private set; }

        private readonly List<Desafio>? _desafios;
        public IReadOnlyCollection<Desafio>? Desafios => _desafios;

        private readonly List<RegistroFrequencia>? _registroFrequencias;
        public virtual IReadOnlyCollection<RegistroFrequencia>? RegistroFrequencias => _registroFrequencias;

        protected Participante()
        {

        }

        private Participante(NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento)
        {
            NomeCompleto = nomeCompleto;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
            _desafios = new List<Desafio>();
            _registroFrequencias = new List<RegistroFrequencia>();
        }

        public static Participante Registrar(NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento)
        {
            return new Participante(nomeCompleto, sexo, dataDeNascimento);
        }

        public void Editar(NomeCompleto nomeCompleto, Sexo sexo, DataDeNascimento dataDeNascimento)
        {
            DomainExceptionValidation.When(Id < 0, "Id com valor inválido.");
            NomeCompleto = nomeCompleto;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
        }

        public void AlterarImagem(Imagem imagem)
        {
            Imagem = imagem;
        }

        internal void ParticiparDesafio(Desafio desafio)
        {
            _desafios?.Add(desafio);
        }

        internal void RegistrarFrequencia(RegistroFrequencia registroFrequencia)
        {
            _registroFrequencias?.Add(registroFrequencia);
        }
    }
}
