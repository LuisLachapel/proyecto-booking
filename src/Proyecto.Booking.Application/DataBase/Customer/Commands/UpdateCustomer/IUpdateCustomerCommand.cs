using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public interface IUpdateCustomerCommand
    {
        Task<UpdateCustomerModel> Execute(UpdateCustomerModel model);
    }
}
