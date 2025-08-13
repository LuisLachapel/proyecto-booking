using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto.Booking.Domain.Entities.Booking;

namespace Proyecto.Booking.Domain.Entities.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; }
    }
}
