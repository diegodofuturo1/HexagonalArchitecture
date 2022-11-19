using Domain.Emuns;
using Domain.Entities;
using Application.Ports;
using Application.Manages;
using HotelBookingTest.Mocks;

namespace HotelBookingTest.Tests
{
    internal class GuestManageTest
    {
        private IGuestManage manage;

        [SetUp]
        public void Setup()
        {
            manage = new GuestManage(new GuestRepositoryMock());
        }

        [Test]
        public async Task ShouldCreateGuest()
        {
            var guest = Fixtures.GuestFixture.GetValidPostGuest();
            var response = await manage.Create(guest);

            Assert.IsNotNull(response);
        }


        [Test]
        public void ShouldStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Created));
        }
    }
}