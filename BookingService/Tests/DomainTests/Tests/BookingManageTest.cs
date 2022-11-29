using Domain.Entities;
using HotelBookingTest.Mocks;
using Application.Bookings.Dtos;
using HotelBookingTest.Fixtures;
using Application.Bookings.Ports;
using Application.Bookings.Managers;

namespace HotelBookingTest.Tests
{
    internal class BookingManagerTest
    {
        private IBookingManager manage;

        private readonly Booking booking1 = BookingFixture.GetValidBooking();
        private readonly Booking booking2 = BookingFixture.GetValidBooking();
        private readonly Booking booking3 = BookingFixture.GetValidBooking();

        [SetUp]
        public void Setup()
        {
            manage = new BookingManager(new BookingRepositoryMock());
        }

        [Test]
        public async Task ShouldCreateBooking()
        {
            var entity = BookingFixture.GetValidBooking();
            var created = await manage.Create(new PostBookingDto(entity));

            Assert.Multiple(() =>
            {
                Assert.That(created, Is.Not.Null);
                Assert.That(created.Id, Is.Not.LessThanOrEqualTo(0));
            });
        }

        [Test]
        public async Task ShouldReadBookings()
        {
            var bookingEntity1 = BookingFixture.GetValidBooking();
            var bookingEntity2 = BookingFixture.GetValidBooking();
            var bookingEntity3 = BookingFixture.GetValidBooking();

            var bookingDto1 = await manage.Create(new PostBookingDto(bookingEntity1));
            var bookingDto2 = await manage.Create(new PostBookingDto(bookingEntity2));
            var bookingDto3 = await manage.Create(new PostBookingDto(bookingEntity3));

            var response = await manage.Read();

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.EqualTo(3));
                Assert.That(response.ToList().Find(x => x.Id == bookingDto1.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == bookingDto2.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == bookingDto3.Id), Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldReadByIdBookings()
        {
            var g1 = await manage.Create(new PostBookingDto(booking1));
            var g2 = await manage.Create(new PostBookingDto(booking2));
            var g3 = await manage.Create(new PostBookingDto(booking3));

            var response1 = await manage.Read(g1.Id);
            var response2 = await manage.Read(g2.Id);
            var response3 = await manage.Read(g3.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response1, Is.Not.Null);
                Assert.That(response2, Is.Not.Null);
                Assert.That(response3, Is.Not.Null);
            });
        }

        [Test]
        public async Task ShouldUpdateBookings()
        {
            var created1 = await manage.Create(new PostBookingDto(booking1));
            var created2 = await manage.Create(new PostBookingDto(booking2));
            var created3 = await manage.Create(new PostBookingDto(booking3));

            var update1 = BookingFixture.GetValidPutBooking(created1.Id);
            var update2 = BookingFixture.GetValidPutBooking(created2.Id);
            var update3 = BookingFixture.GetValidPutBooking(created3.Id);

            await manage.Update(update1);
            await manage.Update(update2);
            await manage.Update(update3);

            var updated1 = await manage.Read(created1.Id);
            var updated2 = await manage.Read(created2.Id);
            var updated3 = await manage.Read(created3.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updated1, Is.Not.Null);
                Assert.That(updated2, Is.Not.Null);
                Assert.That(updated3, Is.Not.Null);
                Assert.That(updated1.Id, Is.EqualTo(created1.Id));
                Assert.That(updated2.Id, Is.EqualTo(created2.Id));
                Assert.That(updated3.Id, Is.EqualTo(created3.Id));
                Assert.That(updated1.Start, Is.Not.EqualTo(created1.Start));
                Assert.That(updated2.Start, Is.Not.EqualTo(created2.Start));
                Assert.That(updated3.Start, Is.Not.EqualTo(created3.Start));
            });
        }

        [Test]
        public async Task ShouldDeleteBookings()
        {
            var created1 = await manage.Create(new PostBookingDto(booking1));
            var created2 = await manage.Create(new PostBookingDto(booking2));
            var created3 = await manage.Create(new PostBookingDto(booking3));

            await manage.Delete(created1.Id);
            await manage.Delete(created2.Id);
            await manage.Delete(created3.Id);

            var updated1 = await manage.Read(created1.Id);
            var updated2 = await manage.Read(created2.Id);
            var updated3 = await manage.Read(created3.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updated1, Is.Null);
                Assert.That(updated2, Is.Null);
                Assert.That(updated3, Is.Null);
            });
        }

        [Test]
        public async Task ShouldNotDeleteBookings()
        {
            await manage.Delete(1);

            var response = await manage.Read();

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.EqualTo(0));
            });
        }

        [Test]
        public async Task ShouldNotReadByInvalidIdBookings()
        {
            var response = await manage.Read(1);

            Assert.That(response, Is.Null);
        }
    }
}