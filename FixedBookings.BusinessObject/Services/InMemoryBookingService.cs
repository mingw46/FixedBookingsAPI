using FixedBookings.BusinessObject.Interfaces;
using FixedBookings.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedBookings.BusinessObject.Services
{
    public class InMemoryBookingService : IBookingService
    {
        private readonly List<Booking> bookings = new List<Booking>();
        private long currentId = 0;

        public Task<Booking> Add(Booking booking)
        {
            booking.Id = ++currentId;
            bookings.Add(booking);
            return Task.FromResult(booking);
        }

        public Task<ReadOnlyCollection<Booking>> GetAll()
        {
            return Task.FromResult(bookings.AsReadOnly());
        }

        public Task<Booking> GetById(long Id)
        {
            return Task.FromResult(bookings.SingleOrDefault(b => b.Id == Id));
        }

    }
}
