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
            var bookings = await _context.Bookings
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize).ToListAsync();
            return bookings.ToService();
        }

        public async Task<Booking> GetByIdAsync(long id)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == id);
            return booking.ToService();
        }

        public async Task<Booking> GetByOrderedDate(DateTime startDate, DateTime endDate)
        {
            var booking = await _context.Bookings.SingleOrDefaultAsync(b => b.StartDate >= startDate && b.EndDate <= endDate);
            return booking.ToService();
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            var bookingEntity = booking.ToEntity();
            bookingEntity.CreationDate = DateTime.Now;
            bookingEntity.IsActive = true;
            var addedBookingEntry = _context.Bookings.Add(bookingEntity);
            await _context.SaveChangesAsync();
            return addedBookingEntry.Entity.ToService();
        }


        public async Task<Booking> UpdateAsync(Booking booking)
        {
            var existingBooking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == booking.Id);
            _context.Entry(existingBooking).CurrentValues.SetValues(booking.ToEntity());
            await _context.SaveChangesAsync();
            return existingBooking.ToService();
        }


        public async Task<Booking> DisableAsync(long id)
        {
            var existingBooking = await _context.Bookings.SingleOrDefaultAsync(b => b.Id == id);
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
