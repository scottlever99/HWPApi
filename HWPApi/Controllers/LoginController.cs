using HWPApi.Models;
using HWPApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HWPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginRequest loginDetails)
        {
            if (!_loginService.Login(loginDetails.Username, loginDetails.Password, out var user)) return BadRequest();
            return Ok(user);
        }
    }
}
