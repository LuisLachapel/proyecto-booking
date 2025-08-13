using Microsoft.EntityFrameworkCore;
namespace Proyecto.Booking.Application.DataBase.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery: IGetAllBookingsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        public GetAllBookingsQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from bookings in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on bookings.CustomerId equals customer.CustomerId
                                select new GetAllBookingsModel
                                {
                                    BookingId = bookings.BookingId,
                                    Code = bookings.Code,
                                    RegisterDate = bookings.RegisterDate,
                                    Type = bookings.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber
                                }).ToListAsync();

            return result;
        }
    }
}
