using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery: IGetCustomerByIdQuery
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService; 
        public GetCustomerByIdQuery(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }
        public async Task<GetCustomerByIdModel> Execute(int customerId)
        {
            var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return _mapper.Map<GetCustomerByIdModel>(entity);
        }
    }
}
