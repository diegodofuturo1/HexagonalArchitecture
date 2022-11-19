
using Domain.Ports;
using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;
using System.Linq.Expressions;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Mocks
{
    internal class GuestRepositoryMock : IGuestRepository
    {
        private List<Guest> guests = GuestFixture.GetValidListGuests(100);

        public Task<Guest> Delete(long id)
        {
            var entity = guests.Find(guest => guest.Id == id);
            guests.Remove(entity);
            return Task.FromResult(entity);
        }

        public Task<Guest> GetByEmail(string email)
        {
            var entity = guests.Find(guest => guest.Email == email);
            return Task.FromResult(entity);
        }

        public Task<Guest> Insert(Guest entity)
        {
            entity.Id = GuestFixture.GetId();
            guests.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<Guest>> Search(Expression<Func<Guest, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> SearchByEmail(string email)
        {
            var entities = guests.FindAll(guest => guest.Email.Contains(email));
            return Task.FromResult((IEnumerable<Guest>)entities);
        }

        public Task<IEnumerable<Guest>> SearchByName(string name)
        {
            var entities = guests.FindAll(guest => guest.FirstName.Contains(name));
            return Task.FromResult((IEnumerable<Guest>)entities);
        }

        public Task<Guest> Select(long id)
        {
            var entity = guests.Find(guest => guest.Id == id);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<Guest>> Select()
        {
            return Task.FromResult((IEnumerable<Guest>)guests);
        }

        public Task<Guest> Select(Expression<Func<Guest, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Update(Guest entity)
        {
            var update = guests.Find(guest => guest.Id == entity.Id);

            update.Email = entity.Email;
            update.FirstName = entity.FirstName;
            update.LastName = entity.LastName;
            update.Document.DocumentId = entity.Document.DocumentId;
            update.Document.DocumentType = entity.Document.DocumentType;

            return Task.FromResult(update);
        }
    }
}
