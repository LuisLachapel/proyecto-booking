using FluentValidation;
using Proyecto.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;

namespace Proyecto.Booking.Application.Validators.Customer
{
    public class UpdateCustomerValidator: AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);

        }
    }
}
