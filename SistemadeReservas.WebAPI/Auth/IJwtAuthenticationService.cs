namespace SistemadeReservas.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
