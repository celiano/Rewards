using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface IUserDA
    {
        Response<User> GetUser(string userName, string password);
    }
}