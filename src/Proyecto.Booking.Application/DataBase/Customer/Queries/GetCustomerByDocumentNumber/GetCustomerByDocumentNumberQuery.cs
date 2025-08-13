using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public class GetCustomerByDocumentNumberQuery: IGetCustomerByDocumentNumberQuery
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public GetCustomerByDocumentNumberQuery(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }
        public async Task<GetCustomerByDocumentNumberModel> Execute(string documentNumber)
        {
            var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);
            return _mapper.Map<GetCustomerByDocumentNumberModel>(entity);
        }
    }
}
