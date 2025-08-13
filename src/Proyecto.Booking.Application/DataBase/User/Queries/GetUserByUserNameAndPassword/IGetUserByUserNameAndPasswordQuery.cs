using Proyecto.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;

namespace Proyecto.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
    public interface IGetUserByUserNameAndPasswordQuery
    {
        Task<GetUserByUserNameAndPasswordModel> Execute(string UserName, string Password);
    }
}
