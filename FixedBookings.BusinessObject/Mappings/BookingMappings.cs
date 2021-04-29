using FixedBookings.BusinessObject.Models;
using FixedBookings.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedBookings.BusinessLogic.Mappings
{
    public static class BookingMappings
    {
        public static Booking ToService(this BookingEntity entity)
        {
            return entity != null ? new Booking { 
                Id = entity.Id, Comments = entity.Comments,
                CustomerName = entity.CustomerName, EndDate = entity.EndDate, 
                FieldName = entity.FieldName,
                PhoneNumber = entity.PhoneNumber, 
                StartDate = entity.StartDate,
                CreationDate = entity.CreationDate, IsActive = entity.IsActive
            } : null;
        }

        public static BookingEntity ToEntity(this Booking model)
        {
            return model != null ? new BookingEntity {
                Id = model.Id, Comments = model.Comments, 
                CustomerName = model.CustomerName, EndDate = model.EndDate,
                FieldName = model.FieldName, PhoneNumber = model.PhoneNumber,
                StartDate = model.StartDate, CreationDate = model.CreationDate,
                IsActive = model.IsActive } : null;
        }

        public static IReadOnlyCollection<Booking> ToService(this IReadOnlyCollection<BookingEntity> entities) => entities.MapCollection(ToService);
    }
}
