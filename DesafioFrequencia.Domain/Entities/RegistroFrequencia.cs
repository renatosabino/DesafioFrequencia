using DesafioFrequencia.Domain.Exceptions;
using DesafioFrequencia.Domain.Utils;
using DesafioFrequencia.Domain.ValueObjects;

namespace DesafioFrequencia.Domain.Entities
{
    public sealed class RegistroFrequencia : Entity
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

        public static void IncluirComparecimento(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem)
        {
            var registroFrequencia = new RegistroFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.Comparecimento);
            participante.AdicionaRegistroFrequencia(registroFrequencia);
        }

        public static void IncluirFalta(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem)
        {
            var registroFrequencia = new RegistroFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.Falta);
            participante.AdicionaRegistroFrequencia(registroFrequencia);
        }
        public static void IncluirDayOff(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem)
        {
            DomainExceptionValidation.When(!EhPermitidoODayOff(dataFrequencia, desafio, participante),
                "Já foram incluidos a quantidade máxima de dayoffs na semana.");

            var registroFrequencia = new RegistroFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.DayOff);
            participante.AdicionaRegistroFrequencia(registroFrequencia);
        }
        public static void IncluirFaltaJustificada(DataFrequencia dataFrequencia, Desafio desafio, Participante participante, Imagem imagem)
        {
            var registroFrequencia = new RegistroFrequencia(dataFrequencia, desafio, participante, imagem, EstadoFrequencia.FaltaJustificada);
            participante.AdicionaRegistroFrequencia(registroFrequencia);
        }
        private static bool EhPermitidoODayOff(DataFrequencia dataFrequencia, Desafio desafio, Participante participante)
        {
            var diaInicioSemana = dataFrequencia.Data.InicioDaSemana(desafio.Regra.InicioDaSemana);
            var diaFimSemana = dataFrequencia.Data.FimDaSemana(desafio.Regra.InicioDaSemana);

            var quantidadeDayOffNaSemana = participante.RegistroFrequencias?
                .Count(rf => (rf.DataFrequencia.Data >= diaInicioSemana && rf.DataFrequencia.Data <= diaFimSemana) &&
                             rf.EstadoFrequencia.Tipo.Equals(EstadoFrequencia.DayOff.ToString()));

            var quantidadeDayOffPermitida = desafio.Regra.QuantidadeDiasObrigatorio - Desafio.DIAS_NA_SEMANA;

            return quantidadeDayOffNaSemana <= quantidadeDayOffPermitida;
        }
    }
}
