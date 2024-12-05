using API_Test_UserChangePass.Data;
using API_Test_UserChangePass.Models;
using API_Test_UserChangePass.Utility;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

namespace API_Test_UserChangePass.Repositories
{
    public class Repositorie : IRepositories
    {
        private  UserCPDbContext _DbContext;
        private readonly TokenService _tokService;
        public Repositorie(UserCPDbContext DbContext, TokenService tokService)
        {
            _DbContext = DbContext;
            _tokService = tokService;

        }
    








        public string GetToken(UserModel users)
        {
            var user = _DbContext.Userx.Where(p => p.UserName == users.UserName ).ToList();
            foreach (var item in user) {

                if (HashPasswordBCrypt.VerifyPassword(users.Password, item.PasswordHash))
                {
                    
                    return _tokService.GenerateToken(item.UserName, item.Email, item.RegisterDate.ToString(),item.IsAdmin.ToString());
                }
            
            }
            //_tokService.GenerateToken(user)
            return "Not Fond";
        }
    }
}
