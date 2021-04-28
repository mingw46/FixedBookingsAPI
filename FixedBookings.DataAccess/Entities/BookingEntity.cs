using System;
using System.Collections.Generic;
using System.Text;

namespace FixedBookings.DataAccess.Entities
{
    public class BookingEntity : BaseEntity
    {
        public string FieldName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
    }
}
