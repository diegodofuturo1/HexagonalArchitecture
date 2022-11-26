using Domain.Ports;
using Domain.Entities;
using SqlAdapter.Contexts;

namespace SqlAdapter.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelDbContext context) : base(context)
        {
        }
    }
}
