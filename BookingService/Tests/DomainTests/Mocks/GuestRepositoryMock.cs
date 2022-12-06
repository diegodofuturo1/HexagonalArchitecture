
using Domain.Ports;
using Domain.Entities;
using System.Linq.Expressions;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Mocks
{
    internal class GuestRepositoryMock : RepositoryMock<Guest>, IGuestRepository
    {
        public GuestRepositoryMock()
        {
            entitys.Add(GuestFixture.GetValidGuest(1));
        }

        public Task<Guest> GetByEmail(string email)
        {
            return Task.FromResult(Select().Result.FirstOrDefault(x => x.Email == email));
        }

        public Task<IEnumerable<Guest>> SearchByEmail(string email)
        {
            return Task.FromResult(Select().Result.Where(x => x.Email.ToLower().Contains(email.ToLower())));
        }

        public Task<IEnumerable<Guest>> SearchByName(string name)
        {
            return Task.FromResult(Select().Result.Where(x => x.FirstName.ToLower().Contains(name.ToLower())));
        }
    }
}
