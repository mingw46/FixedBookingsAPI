using System;
using System.Collections.Generic;
using System.Text;

namespace FixedBookings.BusinessObject.Models
{
    public class Booking
    {
        public long Id { get; set; }
        public string FieldName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
    }
}
