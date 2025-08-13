using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery: IGetAllCustomerQuery
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public GetAllCustomerQuery(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllCustomerModel>> Execute()
        {
            var listEntities = await _dataBaseService.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomerModel>>(listEntities);
        }
    }
}
