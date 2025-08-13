using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand: IDeleteUserCommand
    {
        private readonly IDataBaseService _database;
        public DeleteUserCommand(IDataBaseService database)
        {
            _database = database;
        }
        public async Task<bool> Execute(int userId)
        {
            var entity = await _database.User.FirstOrDefaultAsync(x => x.UserId == userId);
            if(entity == null)
            {
                return false;
            }
            _database.User.Remove(entity);
            return await _database.SaveAsync();
        }
    }
}
