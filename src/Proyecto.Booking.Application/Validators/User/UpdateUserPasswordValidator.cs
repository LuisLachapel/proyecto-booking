using FluentValidation;
using Proyecto.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Proyecto.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator: AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);
            RuleFor(x => x.Password).NotEmpty().NotEmpty().MaximumLength(10);
        }
    }
}
