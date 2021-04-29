using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedBookings.Service.API.Models
{
    public class BookingModel
    {
        public long Id { get; set; }
        public string FieldName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
