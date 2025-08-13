namespace Proyecto.Booking.Application.DataBase.Bookings.Queries.GetAllBookings
{
    public interface IGetAllBookingsQuery
    {
        Task<List<GetAllBookingsModel>> Execute();
    }
}
