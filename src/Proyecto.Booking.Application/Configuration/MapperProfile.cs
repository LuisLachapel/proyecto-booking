using AutoMapper;
using Proyecto.Booking.Domain.Entities.User;
using Proyecto.Booking.Application.DataBase.User.Commands.CreateUser;
using Proyecto.Booking.Application.DataBase.User.Commands.UpdateUser;
using Proyecto.Booking.Application.DataBase.User.Queries.GetAllUser;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserById;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserByNameAndPassword;
using Proyecto.Booking.Domain.Entities.Customer;
using Proyecto.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Proyecto.Booking.Domain.Entities.Booking;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;

namespace Proyecto.Booking.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            //User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();

            //Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();

            //Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();


            //CreateMap<BookingEntity, GetAllBookingsModel>().ReverseMap();
        }
    }
}
