
using Domain.Ports;
using Domain.Entities;
using System.Linq.Expressions;

namespace HotelBookingTest.Mocks
{
    internal class GuestRepositoryMock : IGuestRepository
    {
        public Task<Guest> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Insert(Guest entity)
        {
            entity.Id = Fixtures.GuestFixture.GetId();
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<Guest>> Search(Expression<Func<Guest, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> SearchByName(string name)
        {
            throw new NotImplementedException();
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

        public Task<Guest> Select(Expression<Func<Guest, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Update(long id, Guest entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Update(Guest entity)
        {
            throw new NotImplementedException();
        }
    }
}
