using FluentValidation;
using Proyecto.Booking.Application.DataBase.User.Commands.CreateUser;

namespace Proyecto.Booking.Application.Validators.User
{
    public class CreateUserValidator: AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}
