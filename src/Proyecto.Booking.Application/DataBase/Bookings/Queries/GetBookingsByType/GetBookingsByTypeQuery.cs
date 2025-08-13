using Microsoft.EntityFrameworkCore;
namespace Proyecto.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType
{
    public class GetBookingsByTypeQuery: IGetBookingsByTypeQuery
    {
        private readonly IDataBaseService _databaseService;
        public GetBookingsByTypeQuery(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<GetBookingsByTypeModel>> Execute(string type)
        {
            var result = await (from bookings in _databaseService.Booking
                                join customer in _databaseService.Customer
                                on bookings.CustomerId equals customer.CustomerId
                                where bookings.Type == type
                                select new GetBookingsByTypeModel
                                {
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
