using ASP_Coffe.Implementation.Commands.Create;
using ASP_Coffe.Implementation.Commands.Delete;
using ASP_Coffe.Implementation.Commands.Update;
using ASP_Coffe.Implementation.Queries;
using ASP_Coffee.Application;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Searches;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Coffee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {

        private readonly UseCase _executor;
        public CoffeeController(UseCase executor)
        {
            _executor = executor;
        }
        // GET: api/<CoffeeController>
        [HttpGet]
        public IActionResult Get([FromQuery] CoffeeSearch search, [FromServices] GetCoffee query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<CoffeeController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] CoffeeDto dto, [FromServices] CreateCoffee command)
        {

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);
            var newImageName = guid + extension;
            var path = Path.Combine("wwwroot", "images", newImageName);
         
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }


            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully added new coffee!");
        }

        // PUT api/<CoffeeController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromForm] CoffeeDto dto, [FromServices] UpdateCoffee command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return Ok("You have successfully updated choosen coffee!");
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteCoffee command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("You have successfully deleted choosen coffee!");
        }
    }
}
