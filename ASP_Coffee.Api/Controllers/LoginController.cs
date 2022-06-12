using ASP_Coffee.Api.Core;
using ASP_Coffee.Application.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MenagerJwt _manager;

        public LoginController(MenagerJwt manager)
        {
            _manager = manager;
        }

        // POST: api/<Login/Controller>
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto dto)
        {
            var token = _manager.MakeToken(dto.Email, dto.Password);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }

    }
}
