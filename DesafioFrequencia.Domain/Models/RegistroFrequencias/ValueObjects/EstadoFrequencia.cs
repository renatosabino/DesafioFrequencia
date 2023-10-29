namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects
{
    public class EstadoFrequencia
    {
        public string Tipo { get; private set; }

        private EstadoFrequencia(string tipo)
        {
            Tipo = tipo;
        }

        public static EstadoFrequencia Comparecimento => new EstadoFrequencia("Comparecimento");
        public static EstadoFrequencia Falta => new EstadoFrequencia("Falta");
        public static EstadoFrequencia DayOff => new EstadoFrequencia("DayOff");
        public static EstadoFrequencia FaltaJustificada => new EstadoFrequencia("FaltaJustificada");

        public static EstadoFrequencia FromString(string tipo)
        {
            switch (tipo)
            {
                case "Comparecimento":
                    return Comparecimento;
                case "Falta":
                    return Falta;
                case "DayOff":
                    return DayOff;
                case "FaltaJustificada":
                    return FaltaJustificada;
                default:
                    throw new ArgumentException("Tipo de frequência inválida");
            }
        }

        public override string ToString()
        {
            return Tipo;
        }
    }
}