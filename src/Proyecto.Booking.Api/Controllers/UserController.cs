using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Booking.Application.DataBase.User.Commands.CreateUser;
using Proyecto.Booking.Application.DataBase.User.Commands.DeleteUser;
using Proyecto.Booking.Application.DataBase.User.Commands.UpdateUser;
using Proyecto.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Proyecto.Booking.Application.DataBase.User.Queries.GetAllUser;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserById;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Proyecto.Booking.Application.Execptions;
using Proyecto.Booking.Application.Features;
using FluentValidation;

namespace Proyecto.Booking.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model, [FromServices] ICreateUserCommand createUserCommand, [FromServices] IValidator<CreateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ResponseApiService.Response(StatusCodes.Status400BadRequest,validate.Errors));
            }
            var data = await createUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel model, [FromServices] IUpdateUserCommand updateUserCommand, [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await updateUserCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordModel model, [FromServices] IUpdateUserPasswordCommand updateUserPasswordCommand, [FromServices] IValidator<UpdateUserPasswordModel> validator)
        {
            var validate = await validator.ValidateAsync(model);
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }
            var data = await updateUserPasswordCommand.Execute(model);
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(int userId, [FromServices] IDeleteUserCommand deleteUserCommand)
        {
            if (userId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            }
            var data = await deleteUserCommand.Execute(userId);
            if (!data)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllUserQuery getAllUserQuery)
        {
            var data = await getAllUserQuery.Execute();
            if (data == null || data.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-id/{userId}")]
        public async Task<IActionResult> GetById(int userId, [FromServices] IGetUserByIdQuery getUserByIdQuery)
        {
            if (userId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
            }
            var data = await getUserByIdQuery.Execute(userId);
            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-username-password/{UserName}/{Password}")]
        public async Task<IActionResult> GetUserByUsernamePassword(string UserName, string Password, [FromServices] IGetUserByUserNameAndPasswordQuery getUserByUserNameAndPasswordQuery, [FromServices] IValidator<(string, string)> validator)
        {
            var validate = await validator.ValidateAsync((UserName,Password));
            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await getUserByUserNameAndPasswordQuery.Execute(UserName, Password);
            if(data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));
            }
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK,data));
        }


    }
}
