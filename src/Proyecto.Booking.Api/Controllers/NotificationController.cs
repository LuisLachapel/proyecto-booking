using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Booking.Application.Execptions;
using Proyecto.Booking.Application.External.SendGridEmail;
using Proyecto.Booking.Application.Features;
using Proyecto.Booking.Domain.Models.SendGridEmail;

namespace Proyecto.Booking.Api.Controllers
{
    [Route("api/v1/notification")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class NotificationController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SendGridEmailRequestModel model, [FromServices] ISendGridEmailService sendGridEmail)
        {
            var data = await sendGridEmail.Execute(model);
            if (!data)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseApiService.Response(StatusCodes.Status500InternalServerError,data));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
