using FixedBookings.BusinessLogic.Filters;
using FixedBookings.BusinessObject.Interfaces;
using FixedBookings.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedBookings.BusinessLogic.Services
{
    public class InMemoryBookingService : IBookingService
    {
        private readonly List<Booking> bookings = new List<Booking>();
        private long currentId = 0;

        public Task<IReadOnlyCollection<Booking>> GetAllAsync(PaginationFilter paginationFilter)
        {
            IReadOnlyCollection<Booking> readOnlyBooking = new ReadOnlyCollection<Booking>(bookings
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize).ToList());
            return Task.FromResult(readOnlyBooking);
        }

        public Task<Booking> GetByIdAsync(long Id)
        {
            return Task.FromResult(bookings.SingleOrDefault(b => b.Id == Id));
        }

        public Task<Booking> AddAsync(Booking booking)
        {
            booking.Id = ++currentId;
            bookings.Add(booking);
            return Task.FromResult(booking);
        }

        public Task<Booking> UpdateAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> DisableAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<Booking>> DisableWholeBatchAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetByOrderedDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
