using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto.Booking.Domain.Entities.Booking;

namespace Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommnad: ICreateBookingCommnad
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseService _dataBaseService;

        public CreateBookingCommnad(IMapper mapper, IDataBaseService dataBaseService)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<CreateBookingModel> Execute(CreateBookingModel model)
        {
            var entity = _mapper.Map<BookingEntity>(model);
            entity.RegisterDate = DateTime.Now;
            await _dataBaseService.Booking.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
