using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery: IGetAllUserQuery
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public GetAllUserQuery(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }
        public async Task<List<GetAllUserModel>> Execute()
        {
            var listEntity = await _dataBaseService.User.ToListAsync();
            return _mapper.Map<List<GetAllUserModel>>(listEntity);
        }
    }
}
