using FixedBookings.BusinessLogic.Filters;
using FixedBookings.BusinessObject.Interfaces;
using FixedBookings.BusinessObject.Wrappers;
using FixedBookings.Service.API.Mappings;
using FixedBookings.Service.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedBookings.Service.API.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter paginationFilter)
        {
            var filter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var result = await _bookingService.GetAllAsync(filter);
            return Ok(new PagedResponse<IReadOnlyCollection<BookingModel>>(result.ToModel(), filter.PageNumber, filter.PageSize));
        }


        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var booking = await _bookingService.GetByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking.ToModel());
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(BookingModel model)
        {
            model.Id = 0;
            var booking = await _bookingService.AddAsync(model.ToServiceModel());

            return CreatedAtAction(nameof(GetByIdAsync), new { id = booking.Id }, booking.ToModel());
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAsync(long i, BookingModel model)
        {
            var booking = await _bookingService.UpdateAsync(model.ToServiceModel());

            return Ok(booking.ToModel());
        }

        [HttpPost]
        [Route("disable")]
        public async Task<IActionResult> DisableAsync(long Id)
        {

            var booking = await _bookingService.DisableAsync(Id);

            return Ok(booking.ToModel());
        }

        [HttpPost]
        [Route("disableWholeBatch")]
        public async Task<IActionResult> DisableAsync(string userName)
        {

            var booking = await _bookingService.DisableWholeBatchAsync(userName);

            return Ok(booking.ToModel());
        }

    }
}
