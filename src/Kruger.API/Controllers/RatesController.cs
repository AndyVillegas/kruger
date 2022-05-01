using Kruger.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Kruger.Application.Commands.RateCommands;
using Kruger.Application.Queries.RateQueries;
using Microsoft.AspNetCore.Authorization;
using Common.Pagination;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kruger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatesController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }
        // GET: api/<RateController>
        [HttpGet]
        public async Task<PaginatedResponse<RateDto>> Get([FromQuery] GetAllRatesQuery query)
        {
            return await _mediator.Send(query);
        }

        // GET api/<RateController>/5
        [HttpGet("{Id:int}")]
        public async Task<RateDto> Get([FromRoute] GetRateByIdQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<RateController>
        [HttpPost]
        public async Task<ActionResult<RateDto>> Post([FromBody] CreateRateCommand command)
        {
            var model = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { model.Id }, model);
        }

        // PUT api/<RateController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateRateCommand command)
        {
            command.Id = id;
            await _mediator.Publish(command);
            return AcceptedAtAction(nameof(Get), new { Id = id }, null);
        }

        // DELETE api/<RateController>/5
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteRateCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
