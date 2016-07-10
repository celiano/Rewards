using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface ILoginDA
    {
        Login GetUsuario(string usuario, string clave);
    }
}