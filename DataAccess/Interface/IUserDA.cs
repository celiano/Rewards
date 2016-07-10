using RewardsWebApi.Models;

namespace RewardsWebApi.DataAccess
{
    public interface IUserDA
    {
        Response<User> Authentication(string userName, string password);
    }
}