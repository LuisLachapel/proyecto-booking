using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using Proyecto.Booking.Application.Configuration;
using Proyecto.Booking.Application.DataBase.User.Commands.CreateUser;
using Proyecto.Booking.Application.DataBase.User.Commands.UpdateUser;
using Proyecto.Booking.Application.DataBase.User.Commands.DeleteUser;
using Proyecto.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Proyecto.Booking.Application.DataBase.User.Queries.GetAllUser;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserById;
using Proyecto.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Proyecto.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Proyecto.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Proyecto.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocumentNumber;
using Proyecto.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType;
using Proyecto.Booking.Application.Validators.User;
using Proyecto.Booking.Application.Validators.Customer;
using Proyecto.Booking.Application.Validators.Booking;

namespace Proyecto.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            //User
            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();

            //Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentNumberQuery, GetCustomerByDocumentNumberQuery>();
            
            //Booking
            services.AddTransient<ICreateBookingCommnad, CreateBookingCommnad>();
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingsByDocumentNumberQuery, GetBookingsByDocumentNumberQuery>(); 
            services.AddTransient<IGetBookingsByTypeQuery, GetBookingsByTypeQuery>();

            //validator
            services.AddScoped<IValidator<CreateUserModel>,CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByUsernamePasswordValidator>();
            services.AddScoped<IValidator<CreateCustomerModel>, CreateCustomerValidator>();
            services.AddScoped<IValidator<UpdateCustomerModel>, UpdateCustomerValidator>();
            services.AddScoped<IValidator<CreateBookingModel>, CreateBookingValidator>();


            return services;
        }
    }
}
