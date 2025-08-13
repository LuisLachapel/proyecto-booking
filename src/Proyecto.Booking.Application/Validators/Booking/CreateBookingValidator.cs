using FluentValidation;
using Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking;

namespace Proyecto.Booking.Application.Validators.Booking
{
    public class CreateBookingValidator: AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.Type).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.UserId).NotNull().GreaterThan(0);

        }
    }
}
