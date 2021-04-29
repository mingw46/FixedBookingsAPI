using FixedBookings.BusinessLogic.Filters;
using FixedBookings.BusinessLogic.Mappings;
using FixedBookings.BusinessObject.Interfaces;
using FixedBookings.BusinessObject.Models;
using FixedBookings.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedBookings.BusinessLogic.Services
{
    public class BookingService : IBookingService
    {
        private BookingManagmentDbContext _context;
        public BookingService(BookingManagmentDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Booking>> GetAllAsync(PaginationFilter paginationFilter)
        {
            var bookings = await _context.Bookings.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
        .Take(paginationFilter.PageSize).ToListAsync();
            return bookings.ToService();
        }

        public async Task<Booking> GetByIdAsync(long Id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == Id);
            return booking.ToService();
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            var existingBooking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == booking.Id);
            _context.Entry(existingBooking).CurrentValues.SetValues(booking.ToEntity());
            await _context.SaveChangesAsync();
            return existingBooking.ToService();
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            var addedBookingEntry = _context.Bookings.Add(booking.ToEntity());
            await _context.SaveChangesAsync();
            return addedBookingEntry.Entity.ToService();
        }

        public async Task<Booking> DisableAsync(long Id)
        {
            var existingBooking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == Id);
            existingBooking.IsActive = false;
            await _context.SaveChangesAsync();
            return existingBooking.ToService();
        }
        public async Task<IReadOnlyCollection<Booking>> DisableWholeBatchAsync(string userName)
        {
            var existingBooking = await _context.Bookings.Where(b => b.CustomerName == userName).ToListAsync();
            existingBooking.ForEach(b => b.IsActive = false);
            await _context.SaveChangesAsync();
            return existingBooking.ToService();
        }
    }
}
