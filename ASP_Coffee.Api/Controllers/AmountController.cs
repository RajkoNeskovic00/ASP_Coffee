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
    public class AmountController : ControllerBase
    {
        private readonly UseCase _executor;

        public AmountController(UseCase executor)
        {
            _executor = executor;
        }

        // GET: api/Amount
        [HttpGet]
        public IActionResult Get([FromQuery] AmountSearch search, [FromServices] GetAmounts query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        // POST: api/Amount
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] AmountDto dto, [FromServices] CreateAmount command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new pack amount!");
        }

        // PUT: api/Amount/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] AmountDto dto, [FromServices] UpdateAmount command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen pack amount.");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteAmount command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen pack amount.");
        }
    }
}
