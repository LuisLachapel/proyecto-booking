using Microsoft.AspNetCore.Mvc;
using Proyecto.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Proyecto.Booking.Application.Execptions;
using Proyecto.Booking.Application.Features;
using FluentValidation;

namespace Proyecto.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromServices] ICreateCustomerCommand createCustomerCommand, [FromServices] IValidator<CreateCustomerModel> validator, [FromBody] CreateCustomerModel model )
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await createCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerModel model, [FromServices] IUpdateCustomerCommand updateCustomerCommand, [FromServices] IValidator<UpdateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await updateCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete([FromServices] IDeleteCustomerCommand deleteCustomerCommand, int customerId)
        {
           if(customerId == 0)
           {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await deleteCustomerCommand.Execute(customerId);
            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            return StatusCode(StatusCodes.Status200OK,ResponseApiService.Response(StatusCodes.Status200OK,data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCustomer([FromServices] IGetAllCustomerQuery getAllCustomerQuery)
        {
            var data = await getAllCustomerQuery.Execute();
            if(data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
            return StatusCode(StatusCodes.Status200OK,ResponseApiService.Response(StatusCodes.Status200OK,data));
        }

        [HttpGet("get-by-id/{customerId}")]
        public async Task<IActionResult> GetById([FromServices] IGetCustomerByIdQuery getCustomerByIdQuery, int customerId)
        {
            var data = await getCustomerByIdQuery.Execute(customerId);
            if(customerId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            if(data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            }
           return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-documentNumber/{documentNumber}")]
        public async Task<IActionResult> GetByDocumentNumber([FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery, string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber))
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);
            if(data == null) 
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
