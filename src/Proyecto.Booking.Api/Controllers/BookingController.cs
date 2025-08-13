using Microsoft.AspNetCore.Mvc;
using Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType;
using Proyecto.Booking.Application.Execptions;
using Proyecto.Booking.Application.Features;
using FluentValidation;

namespace Proyecto.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromServices] ICreateBookingCommnad createBookingCommnad, [FromBody] CreateBookingModel model, [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await createBookingCommnad.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookingsQuery)
        {
            var data = await getAllBookingsQuery.Execute();
            if (data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-documentNumber")]
        public async Task<IActionResult> GetByDocumentNumber([FromServices] IGetBookingsByDocumentNumberQuery getBookingsByDocumentNumberQuery, [FromQuery] string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber))
            {
                return StatusCode(StatusCodes.Status400BadRequest,ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await getBookingsByDocumentNumberQuery.Execute(documentNumber);
            if(data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK,ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetByType( [FromServices] IGetBookingsByTypeQuery getBookingsByTypeQuery, [FromQuery] string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await getBookingsByTypeQuery.Execute(type);
            if (data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

    }
}
