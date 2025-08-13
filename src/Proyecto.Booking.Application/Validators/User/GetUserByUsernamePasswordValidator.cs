using FluentValidation;


namespace Proyecto.Booking.Application.Validators.User
{
    public class GetUserByUsernamePasswordValidator: AbstractValidator<(string, string)>
    {
        public GetUserByUsernamePasswordValidator()
        {
            RuleFor(x => x.Item1).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Item2).NotEmpty().NotNull().MaximumLength(10);
        }
    }
}
