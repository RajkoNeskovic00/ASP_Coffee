using ASP_Coffe.Implementation.Queries;
using ASP_Coffee.Application;
using ASP_Coffee.Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogController : ControllerBase
    {
        private readonly UseCase _executor;

        public UseCaseLogController(UseCase executor)
        {
            _executor = executor;
        }

        // GET: api/UseCaseLog
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] GetUseCaseLogs query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
