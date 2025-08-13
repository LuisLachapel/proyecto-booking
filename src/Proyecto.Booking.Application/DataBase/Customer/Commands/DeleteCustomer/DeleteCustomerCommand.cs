using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand: IDeleteCustomerCommand
    {
        private readonly IDataBaseService _databaseServices;
        public DeleteCustomerCommand( IDataBaseService databaseServices)
        {

            _databaseServices = databaseServices;
        }
        public async Task<bool> Execute(int customerId)
        {
            var entity = await _databaseServices.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if(entity == null)
            {
                return false;
            }
            else
            {
                _databaseServices.Customer.Remove(entity);
                return await _databaseServices.SaveAsync();
            }
        }
    }
}
