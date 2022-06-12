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
    public class BeanController : ControllerBase
    {
        private readonly UseCase _executor;

        public BeanController(UseCase executor)
        {
            _executor = executor;
        }



        // GET: api/<BeanController>
        [HttpGet]
        public IActionResult Get([FromQuery] BeanSearch search, [FromServices] GetBeans query)
        {
            return Ok(_executor.ExecuteQuery(query,search));
        }


        // POST api/<BeanController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] BeanDto dto, [FromServices] CreateBean command)
        {
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new type of coffee bean!");
        }

        // PUT api/<BeanController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] BeanDto dto, [FromServices] UpdateBean command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen coffee bean.");
        }

        // DELETE api/<BeanController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id,[FromServices] DeleteBean command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen coffee bean.");
        }
    }
}
