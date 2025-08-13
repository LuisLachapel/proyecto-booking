using AutoMapper;
using Proyecto.Booking.Domain.Entities.Customer;

namespace Proyecto.Booking.Application.DataBase.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public CreateCustomerCommand(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            await _dataBaseService.Customer.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
