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

namespace FixedBookings.BusinessObject.Services
{
    public class BookingService : IBookingService
    {
        private BookingManagmentDbContext _context;
        public BookingService(BookingManagmentDbContext context)
        {
            _context = context;
        }
        public Task<Booking> Add(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<Booking>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetById(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
