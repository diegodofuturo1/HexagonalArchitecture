
using Domain.Ports;
using Domain.Entities;

namespace HotelBookingTest.Mocks
{
    internal class GuestRepositoryMock : IGuestRepository
    {
        public Task<Guest> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Insert(Guest entity)
        {
            entity.Id = Fixtures.GuestFixture.GetId();
            return Task.FromResult(entity);
        }

        public Task<Guest> Select(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> Select(string prop, string value)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Update(long id, Guest entity)
        {
            throw new NotImplementedException();
        }
    }
}
