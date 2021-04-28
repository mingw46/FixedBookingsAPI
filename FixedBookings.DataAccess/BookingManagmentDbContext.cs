using FixedBookings.DataAccess.Configurations;
using FixedBookings.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FixedBookings.DataAccess
{
    public class BookingManagmentDbContext : DbContext
    {
        public DbSet<BookingEntity> Bookings { get; set; }

        public BookingManagmentDbContext(DbContextOptions<BookingManagmentDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
        }

    }
}
