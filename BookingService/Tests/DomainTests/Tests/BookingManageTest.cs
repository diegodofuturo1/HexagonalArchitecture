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

        [SetUp]
        public void Setup()
        {
            manage = new BookingManager(new BookingRepositoryMock(), new GuestRepositoryMock(), new RoomRepositoryMock());
        }

        [Test]
        public async Task ShouldCreateBooking()
        {
            var booking = BookingFixture.GetValidBooking();
            var created = await manage.Create(new PostBookingDto(booking));

            Assert.Multiple(() =>
            {
                Assert.That(created, Is.Not.Null);
                Assert.That(created.Id, Is.Not.LessThanOrEqualTo(0));
                Assert.That(created.Room.Id, Is.EqualTo(1));
                Assert.That(created.Guest.Id, Is.EqualTo(1));
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
                Assert.That(response.ToList().Find(x => x.Id == bookingDto1.Id).Room.Id, Is.EqualTo(1));
                Assert.That(response.ToList().Find(x => x.Id == bookingDto1.Id).Guest.Id, Is.EqualTo(1));
                Assert.That(response.ToList().Find(x => x.Id == bookingDto2.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == bookingDto2.Id).Room.Id, Is.EqualTo(1));
                Assert.That(response.ToList().Find(x => x.Id == bookingDto2.Id).Guest.Id, Is.EqualTo(1));
                Assert.That(response.ToList().Find(x => x.Id == bookingDto3.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == bookingDto3.Id).Room.Id, Is.EqualTo(1));
                Assert.That(response.ToList().Find(x => x.Id == bookingDto3.Id).Guest.Id, Is.EqualTo(1));
            });
        }


        [Test]
        public async Task ShouldReadByIdBookings()
        {
            var post = BookingFixture.GetValidPostBooking();

            var created = await manage.Create(post);

            var response = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Id, Is.EqualTo(created.Id));
                Assert.That(response.Room.Id, Is.EqualTo(created.Room.Id));
                Assert.That(response.Guest.Id, Is.EqualTo(created.Guest.Id));
            });
        }

        [Test]
        public async Task ShouldUpdateBookings()
        {
            var post = BookingFixture.GetValidPostBooking();

            var created = await manage.Create(post);

            var update = BookingFixture.GetValidPutBooking(created.Id);

            await manage.Update(update);

            var updated = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updated, Is.Not.Null);
                Assert.That(updated.Id, Is.EqualTo(created.Id));
                Assert.That(updated.Start, Is.Not.EqualTo(created.Start));
                Assert.That(updated.Room.Id, Is.EqualTo(created.Room.Id));
                Assert.That(updated.Guest.Id, Is.EqualTo(created.Guest.Id));
            });
        }

        [Test]
        public async Task ShouldDeleteBookings()
        {
            var post = BookingFixture.GetValidPostBooking();

            var created = await manage.Create(post);

            await manage.Delete(created.Id);

            var response = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Null);
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
            var response = await manage.Read(Fixture.GetId());

            Assert.That(response, Is.Null);
        }
    }
}