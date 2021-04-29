using FixedBookings.BusinessLogic.Filters;
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
        Task<IReadOnlyCollection<Booking>> GetAllAsync(PaginationFilter paginationFilter);
        Task<Booking> GetByIdAsync(long Id);
        Task<Booking> AddAsync(Booking booking);
        Task<Booking> UpdateAsync(Booking booking);
        Task<Booking> DisableAsync(long Id);
        Task<IReadOnlyCollection<Booking>> DisableWholeBatchAsync(string userName);


    }
}
