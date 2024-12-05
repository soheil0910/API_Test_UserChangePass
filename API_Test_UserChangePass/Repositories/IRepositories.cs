using API_Test_UserChangePass.Models;

namespace API_Test_UserChangePass.Repositories
{
    public interface IRepositories
    {
        public string GetToken(UserModel user);
    }
}
