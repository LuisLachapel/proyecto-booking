using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Booking.Application.DataBase.Customer.Queries.GetAllCustomer
{
    public interface IGetAllCustomerQuery
    {
        Task<List<GetAllCustomerModel>> Execute();
    }
}
