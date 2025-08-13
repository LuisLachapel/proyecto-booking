namespace Proyecto.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword
{
    public class GetUserByUserNameAndPasswordModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
