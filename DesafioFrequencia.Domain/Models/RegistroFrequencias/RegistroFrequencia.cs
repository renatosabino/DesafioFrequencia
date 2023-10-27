using DesafioFrequencia.BuildingBlocks.Domain;
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
        public EstadoFrequencia EstadoFrequencia { get; }
        public Imagem Imagem { get; }

        private RegistroFrequencia(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem, EstadoFrequencia estadoFrequencia)
        {
            DataFrequencia = dataFrequencia;
            Desafio = desafio;
            Participante = participante;
            Imagem = imagem;
            EstadoFrequencia = estadoFrequencia;
        }

        public static void IncluirComparecimento(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem) =>
            RegistrarFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.Comparecimento);

        public static void IncluirFalta(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem) =>
            RegistrarFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.Falta);

        public static void IncluirDayOff(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem)
        {
            DomainExceptionValidation.When(!EhPermitidoODayOff(dataFrequencia, desafio, participante),
                "Já foram incluidos a quantidade máxima de dayoffs na semana.");

            RegistrarFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.DayOff);
        }

        public static void IncluirFaltaJustificada(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem) =>
            RegistrarFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.FaltaJustificada);

        private static void RegistrarFrequencia(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem, EstadoFrequencia estadoFrequencia)
        {
            DomainExceptionValidation.When(JaRegistrou(dataFrequencia, desafio, participante), "Já foi registrado a frequência nesta data.");
            var registroFrequencia = new RegistroFrequencia(dataFrequencia, desafio, participante, imagem, estadoFrequencia);
            participante.RegistrarFrequencia(registroFrequencia);
        }

        private static bool JaRegistrou(DataFrequencia dataFrequencia, Desafio desafio, Participante participante)
        {
            var jaRegistrou = participante.RegistroFrequencias?.Any(a => a.Desafio.Id == desafio.Id &&
                a.DataFrequencia.Data == dataFrequencia.Data);

            return jaRegistrou.Value;
        }

        private static bool EhPermitidoODayOff(DataFrequencia dataFrequencia, Desafio desafio, Participante participante)
        {
            var diaInicioSemana = dataFrequencia.Data.InicioDaSemana(desafio.Regra.InicioDaSemana);
            var diaFimSemana = dataFrequencia.Data.FimDaSemana(desafio.Regra.InicioDaSemana);

            var quantidadeDayOffNaSemana = participante.RegistroFrequencias?
                .Count(rf => rf.Desafio.Id == desafio.Id &&
                             (rf.DataFrequencia.Data >= diaInicioSemana && rf.DataFrequencia.Data <= diaFimSemana) &&
                             rf.EstadoFrequencia.Tipo.Equals(EstadoFrequencia.DayOff.ToString()));

            var quantidadeDayOffPermitida = Desafio.DIAS_NA_SEMANA - desafio.Regra.QuantidadeDiasObrigatorio;

            return (quantidadeDayOffNaSemana + 1) <= quantidadeDayOffPermitida;
        }
    }
}
