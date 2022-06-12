using ASP_Coffe.Implementation.Commands.Create;
using ASP_Coffee.Application;
using ASP_Coffee.Application.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UseCase _executor;

        public RegisterController(UseCase executor)
        {
            _executor = executor;
        }


        // POST: api/<RegisterController>
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] CreateUser command)
        {
            _executor.ExecuteCommand(command, dto);

            return Ok("You have successfully registered!");
        }
    }
}
