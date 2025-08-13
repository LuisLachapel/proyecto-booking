namespace Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking
{
    public interface ICreateBookingCommnad
    {
        Task<CreateBookingModel> Execute(CreateBookingModel model);
    }
}
