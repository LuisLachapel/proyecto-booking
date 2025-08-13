using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdQuery: IGetUserByIdQuery
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public GetUserByIdQuery(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<GetUserByIdModel> Execute(int userId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<GetUserByIdModel>(entity);
        }
    }
}
