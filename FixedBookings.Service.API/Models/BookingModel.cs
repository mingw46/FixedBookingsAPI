using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixedBookings.Service.API.Models
{
    public class BookingModel
    {
        public long Id { get; set; }
        [Required]
        public string FieldName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string Comments { get; set; }
    }
}
