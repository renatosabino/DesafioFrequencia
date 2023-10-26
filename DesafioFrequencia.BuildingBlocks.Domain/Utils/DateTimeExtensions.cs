namespace DesafioFrequencia.Domain.Utils
{
    public static class DateTimeExtensions
    {
        public static DateTime InicioDaSemana(this DateTime dateTime, DayOfWeek inicioDaSemana)
        {
            int diff = (7 + (dateTime.DayOfWeek - inicioDaSemana)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        public static DateTime FimDaSemana(this DateTime dateTime, DayOfWeek inicioDaSemana)
        {
            return dateTime.InicioDaSemana(inicioDaSemana).AddDays(6);
        }
    }
}
