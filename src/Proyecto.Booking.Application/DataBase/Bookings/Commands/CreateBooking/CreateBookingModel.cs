namespace Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public int BookingId { get; set; }
        //public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
