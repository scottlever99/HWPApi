using HWPApi.Models;
using HWPApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

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

        [HttpGet("UserEnabled")]
        public ActionResult UserEnabled([FromQuery]int? id = 0, [FromQuery]string? email = "")
        {
            if (id > 0)
            {
                if (_loginService.IsEnabled((int)id)) return Ok(true);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                if (_loginService.IsEnabled(email)) return Ok(true);
            }
            return BadRequest(false);
        }
    }
}
