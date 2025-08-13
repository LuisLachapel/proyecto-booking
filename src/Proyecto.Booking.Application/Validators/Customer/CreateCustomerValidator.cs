using FluentValidation;
using Proyecto.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

namespace Proyecto.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator: AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(8);
        }
    }
}
