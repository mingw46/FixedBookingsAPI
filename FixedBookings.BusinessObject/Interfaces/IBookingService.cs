using FixedBookings.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FixedBookings.BusinessObject.Interfaces
{
    public interface IBookingService
    {
        Task<ReadOnlyCollection<Booking>> GetAll();
        Task<Booking> GetById(long Id);
        Task<Booking> Add(Booking booking);
        //Task<Booking> Remove(Booking booking);
    }
}
