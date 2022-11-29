using Domain.Entities;
using Domain.Ports;
using System.Linq.Expressions;

namespace HotelBookingTest.Mocks
{
    internal class RoomRepositoryMock : RepositoryMock<Room>, IRoomRepository
    {
        public Task<IEnumerable<Room>> Search(Expression<Func<Room, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Room> Select(Expression<Func<Room, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
