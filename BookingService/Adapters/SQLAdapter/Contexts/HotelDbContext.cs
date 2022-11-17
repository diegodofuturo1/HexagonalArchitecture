using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SqlAdapter.Configurations;

namespace SqlAdapter.Contexts
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GuestConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}