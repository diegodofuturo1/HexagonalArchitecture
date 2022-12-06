using Domain.Ports;
using Domain.Entities;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Mocks
{
    internal class RoomRepositoryMock : RepositoryMock<Room>, IRoomRepository
    {
        public RoomRepositoryMock()
        {
            entitys.Add(RoomFixture.GetValidRoom(1));
        }
    }
}
