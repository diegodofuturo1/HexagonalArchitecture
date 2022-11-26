using Domain.Ports;
using Domain.Entities;
using SqlAdapter.Contexts;

namespace SqlAdapter.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelDbContext context) : base(context)
        {
        }
    }
}
