using DesafioFrequencia.BuildingBlocks.Domain;
using DesafioFrequencia.Domain.DomainEvents;
using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.Models.Desafios;
using DesafioFrequencia.Domain.Models.Participantes;
using DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects;
using DesafioFrequencia.Domain.Utils;

namespace DesafioFrequencia.Domain.Models.RegistroFrequencias
{
    public sealed class RegistroFrequencia : Entity, IAggregateRoot
    {
        public DataFrequencia DataFrequencia { get; }
        public Desafio Desafio { get; }
        public Participante Participante { get; }
        public EstadoFrequencia EstadoFrequencia { get; private set; }
        public Modalidade Modalidade { get; private set; }
        public Imagem Imagem { get; private set; }

        protected RegistroFrequencia()
        {

        }

        public RegistroFrequencia(DataFrequencia dataFrequencia, Desafio desafio, Participante participante)
        {
            DataFrequencia = dataFrequencia;
            Desafio = desafio;
            Participante = participante;
        }

        public void Comparecimento(Imagem imagem, Modalidade modalidade)
        {
            DomainExceptionValidation.When(!ParticipanteEstaNoDesafio(), 
                "O participante não está presente no desafio.");

            RegistrarFrequencia(imagem, EstadoFrequencia.Comparecimento, modalidade);

            RaiseDomainEvent(new ComparecimentoDomainEvent(Desafio.Id, Participante.Id));
        }

        public void Falta()
        {
            DomainExceptionValidation.When(!ParticipanteEstaNoDesafio(), 
                "O participante não está presente no desafio.");

            RegistrarFrequencia(EstadoFrequencia.Falta);

            RaiseDomainEvent(new FaltaDomainEvent(Desafio.Id, Participante.Id));
        }

        public void DayOff()
        {
            DomainExceptionValidation.When(!ParticipanteEstaNoDesafio(),
                "O participante não está presente no desafio.");

            DomainExceptionValidation.When(!EhPermitidoODayOff(),
                "Já foram incluidos a quantidade máxima de dayoffs na semana.");

            RegistrarFrequencia(EstadoFrequencia.DayOff);

            RaiseDomainEvent(new DayOffDomainEvent(Desafio.Id, Participante.Id));
        }

        public void FaltaJustificada(Imagem imagem)
        {
            DomainExceptionValidation.When(!ParticipanteEstaNoDesafio(),
                "O participante não está presente no desafio.");

            RegistrarFrequencia(imagem, EstadoFrequencia.FaltaJustificada);

            RaiseDomainEvent(new FaltaJustificadaDomainEvent(Desafio.Id, Participante.Id));
        }

        private void RegistrarFrequencia(Imagem imagem, EstadoFrequencia estadoFrequencia, Modalidade modalidade)
        {
            DomainExceptionValidation.When(JaRegistrou(), "Já foi registrado a frequência nesta data.");
            Imagem = imagem;
            EstadoFrequencia = estadoFrequencia;
            Modalidade = modalidade;
            Participante.RegistrarFrequencia(this);
        }

        private void RegistrarFrequencia(Imagem imagem, EstadoFrequencia estadoFrequencia)
        {
            DomainExceptionValidation.When(JaRegistrou(), "Já foi registrado a frequência nesta data.");
            Imagem = imagem;
            EstadoFrequencia = estadoFrequencia;
            Participante.RegistrarFrequencia(this);
        }

        private void RegistrarFrequencia(EstadoFrequencia estadoFrequencia)
        {
            DomainExceptionValidation.When(JaRegistrou(), "Já foi registrado a frequência nesta data.");
            EstadoFrequencia = estadoFrequencia;
            Participante.RegistrarFrequencia(this);
        }

        private bool JaRegistrou()
        {
            var jaRegistrou = Participante.RegistroFrequencias?.Any(a => a.Desafio.Id == Desafio.Id &&
                a.DataFrequencia.Data.Date == DataFrequencia.Data.Date);

            return jaRegistrou.Value;
        }

        private bool EhPermitidoODayOff()
        {
            var diaInicioSemana = DataFrequencia.Data.InicioDaSemana(Desafio.Regra.InicioDaSemana);
            var diaFimSemana = DataFrequencia.Data.FimDaSemana(Desafio.Regra.InicioDaSemana);

            var quantidadeDayOffNaSemana = Participante.RegistroFrequencias?
                .Count(rf => rf.Desafio.Id == Desafio.Id &&
                             (rf.DataFrequencia.Data >= diaInicioSemana && rf.DataFrequencia.Data <= diaFimSemana) &&
                             rf.EstadoFrequencia.Tipo.Equals(EstadoFrequencia.DayOff.ToString()));

            var quantidadeDayOffPermitida = Desafio.DIAS_NA_SEMANA - Desafio.Regra.QuantidadeDiasObrigatorio;

            return (quantidadeDayOffNaSemana + 1) <= quantidadeDayOffPermitida;
        }

        private bool ParticipanteEstaNoDesafio()
        {
            return Desafio.Participantes.Any(a => a.Id == Participante.Id);
        }
    }
}
