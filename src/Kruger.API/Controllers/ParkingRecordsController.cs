using Kruger.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Kruger.Application.Commands.ParkingRecordCommands;
using Kruger.Application.Queries.ParkingRecordQueries;
using Microsoft.AspNetCore.Authorization;
using Common.Pagination;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kruger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParkingRecordsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingRecordsController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }
        // GET: api/<ParkingRecordController>
        [HttpGet]
        public async Task<PaginatedResponse<ParkingRecordDto>> Get([FromQuery] GetAllParkingRecordsQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<ParkingRecordController>/5
        [HttpGet("{Id:int}")]
        public async Task<ParkingRecordDto> Get([FromRoute] GetParkingRecordByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<ParkingRecordController>
        [HttpPost]
        public async Task<ActionResult<ParkingRecordDto>> Post([FromBody] CreateParkingRecordCommand command)
        {
            var model = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { model.Id }, model);
        }

        // PUT api/<ParkingRecordController>/5
        [HttpPut("{id}/finish")]
        public async Task<ActionResult<FinishedParkingRecordDto>> Put(int id, [FromBody] FinishParkingRecordCommand command)
        {
            command.Id = id;
            var finished = await _mediator.Send(command);
            return AcceptedAtAction(nameof(Get), new { Id = id }, finished);
        }
    }
}
