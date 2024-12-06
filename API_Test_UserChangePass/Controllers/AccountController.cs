using API_Test_UserChangePass.Models;
using API_Test_UserChangePass.Repositories;
using API_Test_UserChangePass.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Test_UserChangePass.Controllers
{
    [Route("api/")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        #region DataClass


        private IRepositories _repositories;
        private ResponseModel _responseModel;


        public AccountController(IRepositories repositories, ResponseModel responseModel)
        {
            _repositories = repositories;
            _responseModel = responseModel;
        }
        #endregion


        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            _responseModel = _repositories.GetToken(_responseModel, user);
            return StatusCode(_responseModel.Status, _responseModel);
        }


        [Authorize]
        [HttpPost("ChengPass")]
        public IActionResult ChengPass([FromBody] UserModelnull user1)
        {
            _responseModel = _repositories.ChengPass(_responseModel, user1, User);
            return StatusCode(_responseModel.Status, _responseModel);
        }


    }
}
