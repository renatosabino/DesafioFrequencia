namespace DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects
{
    public sealed class Modalidade
    {
        public string Tipo { get; private set; }

        private Modalidade(string tipo)
        {
            Tipo = tipo;
        }

        public static Modalidade Academia => new Modalidade("Academia");
        public static Modalidade Caminhada => new Modalidade("Caminhada");
        public static Modalidade Outro => new Modalidade("Outro");

        public static Modalidade FromString(string tipo)
        {
            switch (tipo)
            {
                case "Academia":
                    return Academia;
                case "Caminhada":
                    return Caminhada;
                case "Outro":
                    return Outro;
                default:
                    throw new ArgumentException("Modalidade inválida");
            }
        }

        public override string ToString()
        {
            return Tipo;
        }
    }
}
