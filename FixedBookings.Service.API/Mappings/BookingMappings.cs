using FixedBookings.BusinessObject.Models;
using FixedBookings.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FixedBookings.Service.API.Mappings
{
    public static class BookingMappings
    {
        public static BookingModel ToModel(this Booking model)
        {
            return model != null ? new BookingModel {
                Id = model.Id, Comments = model.Comments, 
                CustomerName = model.CustomerName, EndDate = model.EndDate, 
                FieldName = model.FieldName, PhoneNumber = model.PhoneNumber,
                StartDate = model.StartDate, CreationDate = model.CreationDate,
                IsActive = model.IsActive } : null;
        }

        public static Booking ToServiceModel(this BookingModel model)
        {
            return model != null ? new Booking { 
                Id = model.Id, Comments = model.Comments, 
                CustomerName = model.CustomerName, EndDate = model.EndDate, 
                FieldName = model.FieldName, PhoneNumber = model.PhoneNumber, 
                StartDate = model.StartDate, CreationDate = model.CreationDate,
                IsActive = model.IsActive } : null;
        }

        public static IReadOnlyCollection<BookingModel> ToModel(this IReadOnlyCollection<Booking> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<BookingModel>();
            }

            var bookings = new BookingModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                bookings[i] = model.ToModel();
                ++i;
            }

            return new ReadOnlyCollection<BookingModel>(bookings);
        }
    }
}
