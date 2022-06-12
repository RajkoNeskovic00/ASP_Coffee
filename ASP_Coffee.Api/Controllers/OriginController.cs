using ASP_Coffe.Implementation.Commands.Create;
using ASP_Coffe.Implementation.Commands.Delete;
using ASP_Coffe.Implementation.Commands.Update;
using ASP_Coffe.Implementation.Queries;
using ASP_Coffee.Application;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginController : ControllerBase
    {
        private readonly UseCase _executor;

        public OriginController(UseCase executor)
        {
            _executor = executor;
        }



        // GET: api/Origin
        [HttpGet]
        public IActionResult Get([FromQuery] OriginSearch search, [FromServices] GetOrigins query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST: api/Origin
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OriginDto dto, [FromServices] CreateOrigin command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new origin!");
        }

        // PUT: api/Origin/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] OriginDto dto, [FromServices] UpdateOrigin command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen origin!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteOrigin command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen origin!");
        }
    }
}
