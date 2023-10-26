namespace DesafioFrequencia.Domain.Models.Participantes.ValueObjects
{
    public struct Sexo
    {
        public string Valor { get; private set; }

        private Sexo(string valor)
        {
            Valor = valor;
        }

        public static Sexo Masculino => new Sexo("Masculino");
        public static Sexo Feminino => new Sexo("Feminino");

        public static Sexo FromString(string valor)
        {
            switch (valor)
            {
                case "Masculino":
                    return Masculino;
                case "Feminino":
                    return Feminino;
                default:
                    throw new ArgumentException("Sexo inválido");
            }
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}
