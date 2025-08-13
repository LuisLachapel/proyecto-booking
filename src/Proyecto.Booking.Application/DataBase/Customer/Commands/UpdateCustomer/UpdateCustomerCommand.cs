using AutoMapper;
using Proyecto.Booking.Domain.Entities.Customer;

namespace Proyecto.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand: IUpdateCustomerCommand
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public UpdateCustomerCommand(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }
        public async Task<UpdateCustomerModel> Execute(UpdateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            _dataBaseService.Customer.Update(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
