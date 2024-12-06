using API_Test_UserChangePass.Data;
using API_Test_UserChangePass.Models;
using API_Test_UserChangePass.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Security.Claims;

namespace API_Test_UserChangePass.Repositories
{
    public class Repositorie : IRepositories
    {

        #region DataClass

        private UserCPDbContext _DbContext;
        private readonly TokenService _tokService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Repositorie(UserCPDbContext DbContext, TokenService tokService, IHttpContextAccessor httpContextAccessor)
        {
            _DbContext = DbContext;
            _tokService = tokService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion


        #region GetToken

        public ResponseModel GetToken(ResponseModel response, UserModel users)
        {

            try
            {
                var user = _DbContext.Userx.SingleOrDefault(p => p.UserName == users.UserName);
                if (!(user == null))
                {
                    if (HashPasswordBCrypt.VerifyPassword(users.Password, user.PasswordHash))
                    {
                        response.Status = 200;
                        response.Title = "موفق";
                        response.Description = $"خوش امدید  {user.UserName}";
                        response.value = _tokService.GenerateToken(user.UserName, user.Email, user.RegisterDate.ToString(), user.IsAdmin.ToString());

                        return response;

                    }
                    else
                    {
                        response.Status = 400;
                        response.Title = "خطا";
                        response.Description = "رمز عبور اشتباه است";
                    }
                }
                else
                {
                    response.Status = 404;
                    response.Title = "خطا";
                    response.Description = "کاربر مورد نظر یافت نشد ";
                }
            }
            catch (Exception mess)
            {
                response.Status = 500;
                response.Title = "خطا";
                response.Description = "درخواست شما به درستی انجام نشد لطفا مجددا تلاش نمایید";
                response.value = mess.Message;
            }
            return response;


        }
        #endregion



        #region ChengPass



        public ResponseModel ChengPass(ResponseModel response, UserModelnull users)
        {
            var RequestingUser = _httpContextAccessor.HttpContext?.User.FindFirst("UserName")?.Value;
            var RequestingUserIsAdmin = _httpContextAccessor.HttpContext?.User.FindFirst("IsAdmin")?.Value;

            try
            {
                //چک میکند کاربر ای وارد شده یا ن
                if (users.UserName == null || users.UserName == "" || users.UserName == "string")
                {
                    users.UserName = RequestingUser;
                }
                //کاربر را از دیتا بیس واکشی میکند 
                var user = _DbContext.Userx.FirstOrDefault(p => p.UserName == users.UserName);
                if (!(user == null))
                {
                    //چک میکند کاربر ای که قرار است رمز اش تغییر کند کاربر درخواست دهنده باشد
                    if (RequestingUser == user.UserName)
                    {
                        user.Password_Test = users.Password;
                        user.PasswordHash = HashPasswordBCrypt.HashPassword(users.Password);

                        _DbContext.Userx.Update(user);
                        _DbContext.SaveChanges();



                        response.Status = 200;
                        response.Title = "موفق";
                        response.Description = "تغییر کرد " + user.UserName + " رمز عبور";
                        response.value = "رمز عبور با موفقیت تغییر کرد";

                        return response;

                    }
                    //چک میکند درخواست تغییر رمز کاربر دیگری باشد 
                    else if (RequestingUser != user.UserName)
                    {
                        //چک میکند کاربر درخواست دهنده ادمین باشد 
                        if (RequestingUserIsAdmin == "True")
                        {
                            user.Password_Test = users.Password;
                            user.PasswordHash = HashPasswordBCrypt.HashPassword(users.Password);

                            _DbContext.Userx.Update(user);
                            _DbContext.SaveChanges();

                            response.Status = 200;
                            response.Title = "موفق";
                            response.Description = "تغییر کرد " + user.UserName + " رمز عبور";
                            response.value = RequestingUser + " : " + "رمز عبور با موفقیت تغییر کرد کاربر ";

                            return response;
                        }
                        else
                        {
                            throw new InvalidOperationException("شما ادمین نیستین");

                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("خطابی رخ داده است ");
                }
            }
            catch (Exception mess)
            {
                response.Status = 500;
                response.Title = "خطا";
                response.Description = "درخواست شما به درستی انجام نشد لطفا مجددا تلاش نمایید";
                response.value = mess.Message;


            }
            return response;

        }


        #endregion
    }
}
