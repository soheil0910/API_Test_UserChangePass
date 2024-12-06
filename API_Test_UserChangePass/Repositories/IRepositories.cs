using API_Test_UserChangePass.Models;

namespace API_Test_UserChangePass.Repositories
{
    public interface IRepositories
    {
        public ResponseModel GetToken(ResponseModel response, UserModel users);
        public ResponseModel ChengPass(ResponseModel response, UserModelnull users, System.Security.Claims.ClaimsPrincipal user);
    }
}
