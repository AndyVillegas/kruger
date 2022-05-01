using Kruger.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Kruger.Application.Commands.ParkingPlaceCommands;
using Kruger.Application.Queries.ParkingPlaceQueries;
using Microsoft.AspNetCore.Authorization;
using Common.Pagination;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kruger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParkingPlacesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingPlacesController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }
        // GET: api/<ParkingPlaceController>
        [HttpGet]
        public async Task<PaginatedResponse<ParkingPlaceDto>> Get([FromQuery] GetAllParkingPlacesQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<ParkingPlaceController>/5
        [HttpGet("{Id:int}")]
        public async Task<ParkingPlaceDto> Get([FromRoute] GetParkingPlaceByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<ParkingPlaceController>
        [HttpPost]
        public async Task<ActionResult<ParkingPlaceDto>> Post([FromBody] CreateParkingPlaceCommand command)
        {
            var model = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { model.Id }, model);
        }

        // PUT api/<ParkingPlaceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateParkingPlaceCommand command)
        {
            command.Id = id;
            await _mediator.Publish(command);
            return AcceptedAtAction(nameof(Get), new { Id = id }, null);
        }

        // DELETE api/<ParkingPlaceController>/5
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteParkingPlaceCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
