using System;
using System.Collections.Generic;
using System.Text;

namespace FixedBookings.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
