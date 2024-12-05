using API_Test_UserChangePass.Models;
using API_Test_UserChangePass.Repositories;
using API_Test_UserChangePass.Utility;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Test_UserChangePass.Controllers
{
    [Route("api/")]
    [ApiController]

    public class LoginController : ControllerBase
    {

        private IRepositories _repositories;

        public LoginController(IRepositories repositories)
        {
            _repositories=repositories;
        }

        // GET: api/<LoginController>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserModel user)
        {

           

            
        

            return Ok(_repositories.GetToken(user));


        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
