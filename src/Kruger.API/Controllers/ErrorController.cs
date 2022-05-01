using Kruger.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kruger.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context.Error is NotFoundException)
            {
                return NotFound(new
                {
                    message = context.Error.Message
                });
            }
            else if (context.Error is ValidationErrorException)
            {
                return BadRequest(new
                {
                    message = context.Error.Message
                });
            }
            return StatusCode((int)HttpStatusCode.InternalServerError, new
            {
                message = context.Error.Message,
                Details = context.Error.StackTrace
            });
        }
    }
}
