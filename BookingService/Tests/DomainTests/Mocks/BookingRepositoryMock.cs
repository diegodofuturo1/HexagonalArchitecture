using Domain.Entities;
using Domain.Ports;
using HotelBookingTest.Fixtures;
using System.Linq.Expressions;

namespace HotelBookingTest.Mocks
{
    internal class BookingRepositoryMock : RepositoryMock<Booking>, IBookingRepository
    {
    }
}
