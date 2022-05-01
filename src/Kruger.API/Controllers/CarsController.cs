using Kruger.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Kruger.Application.Commands.CarCommands;
using Kruger.Application.Queries.CarQueries;
using Microsoft.AspNetCore.Authorization;
using Common.Pagination;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kruger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }
        // GET: api/<CarController>
        [HttpGet]
        public async Task<PaginatedResponse<CarDto>> Get([FromQuery] GetAllCarsQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<CarController>/5
        [HttpGet("{Id:int}")]
        public async Task<CarDto> Get([FromRoute] GetCarByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<ActionResult<CarDto>> Post([FromBody] CreateCarCommand command)
        {
            var model = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { model.Id }, model);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCarCommand command)
        {
            command.Id = id;
            await _mediator.Publish(command);
            return AcceptedAtAction(nameof(Get), new { Id = id }, null);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteCarCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
