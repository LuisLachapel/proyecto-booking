using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;

namespace Proyecto.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public class GetUserByUserNameAndPasswordQuery: IGetUserByUserNameAndPasswordQuery
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;
        public GetUserByUserNameAndPasswordQuery(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }
        public async Task<GetUserByUserNameAndPasswordModel>Execute(string UserName, string Password)
        {
           var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserName == UserName && Password == Password);
            return _mapper.Map<GetUserByUserNameAndPasswordModel>(entity);
        }
    }
}
