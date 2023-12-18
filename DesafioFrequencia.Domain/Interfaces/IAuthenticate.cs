namespace DesafioFrequencia.Domain.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(string email, string password);
        Task Logout();
    }
}
