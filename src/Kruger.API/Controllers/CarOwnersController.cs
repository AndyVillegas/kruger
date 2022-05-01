using Kruger.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Kruger.Application.Commands.CarOwnerCommands;
using Kruger.Application.Queries.CarOwnerQueries;
using Microsoft.AspNetCore.Authorization;
using Common.Pagination;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kruger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarOwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarOwnersController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }
        // GET: api/<CarOwnerController>
        [HttpGet]
        public async Task<PaginatedResponse<CarOwnerDto>> Get([FromQuery] GetAllCarOwnersQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<CarOwnerController>/5
        [HttpGet("{Id:int}")]
        public async Task<CarOwnerDto> Get([FromRoute] GetCarOwnerByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<CarOwnerController>
        [HttpPost]
        public async Task<ActionResult<CarOwnerDto>> Post([FromBody] CreateCarOwnerCommand command)
        {
            var model = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { model.Id }, model);
        }

        // PUT api/<CarOwnerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateCarOwnerCommand command)
        {
            command.Id = id;
            await _mediator.Publish(command);
            return AcceptedAtAction(nameof(Get), new { Id = id}, null);
        }

        // DELETE api/<CarOwnerController>/5
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteCarOwnerCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
