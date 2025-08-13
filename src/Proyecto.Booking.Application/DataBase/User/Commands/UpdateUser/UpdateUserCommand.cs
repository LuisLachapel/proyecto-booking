using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Proyecto.Booking.Domain.Entities.User;

namespace Proyecto.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand: IUpdateUserCommand
    {
        private readonly IDataBaseService _database;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<UpdateUserModel> Execute(UpdateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            _database.User.Update(entity);  
            await _database.SaveAsync();
            return model;
        }
    }
}
