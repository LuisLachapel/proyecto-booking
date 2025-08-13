using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Booking.Domain.Entities.Booking;
using Proyecto.Booking.Domain.Entities.Customer;
using Proyecto.Booking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Booking.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<CustomerEntity> Customer { get; set; }
        DbSet<BookingEntity> Booking { get; set; }
        Task<bool> SaveAsync();
    }
}
