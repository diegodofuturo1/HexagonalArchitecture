using Domain.Entities;
using Domain.Ports;
using System.Linq.Expressions;

namespace HotelBookingTest.Mocks
{
    internal class BookingRepositoryMock : RepositoryMock<Booking>, IBookingRepository
    {
        public Task<IEnumerable<Booking>> Search(Expression<Func<Booking, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> Select(Expression<Func<Booking, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
