using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.SqlAdapter
{
    public class HotelDbContext: DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options): base(options) { }

        public virtual DbSet<Guest> Guests { get; set; }
    }
}