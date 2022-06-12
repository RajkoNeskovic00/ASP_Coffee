using ASP_Coffe.Implementation.Commands.Create;
using ASP_Coffe.Implementation.Commands.Delete;
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
    public class OrderController : ControllerBase
    {
        private readonly UseCase _executor;

        public OrderController(UseCase executor)
        {
            _executor = executor;
        }

        // GET: api/Order
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] GetOrders query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST: api/Order
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] CreateOrder command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("Thank You for Your purchase!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteOrder command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen order!");
        }
    }
}
