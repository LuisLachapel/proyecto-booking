﻿namespace Proyecto.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber
{
    public interface IGetBookingsByDocumentNumberQuery
    {
        Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber);
    }
}
