using Domain.Entities;
using Domain.Exceptions;
using HotelBookingTest.Mocks;
using Application.Guests.Dtos;
using Application.Guests.Ports;
using HotelBookingTest.Fixtures;
using Application.Guests.Manages;

namespace HotelBookingTest.Tests
{
    internal class GuestManagerTest
    {
        private IGuestManager manage;

        private readonly Guest guest1 = GuestFixture.GetValidGuest();
        private readonly Guest guest2 = GuestFixture.GetValidGuest();
        private readonly Guest guest3 = GuestFixture.GetValidGuest();

        [SetUp]
        public void Setup()
        {
            manage = new GuestManager(new GuestRepositoryMock());
        }

        [Test]
        public async Task ShouldCreateGuest()
        {
            var entity = GuestFixture.GetValidGuest();
            var created = await manage.Create(new PostGuestDto(entity));

            Assert.Multiple(() =>
            {
                Assert.That(created, Is.Not.Null);
                Assert.That(created.Id, Is.Not.LessThanOrEqualTo(0));
            });
        }

        [Test]
        public async Task ShouldReadGuests()
        {
            var guestEntity1 = GuestFixture.GetValidGuest();
            var guestEntity2 = GuestFixture.GetValidGuest();
            var guestEntity3 = GuestFixture.GetValidGuest();

            var guestDto1 = await manage.Create(new PostGuestDto(guestEntity1));
            var guestDto2 = await manage.Create(new PostGuestDto(guestEntity2));
            var guestDto3 = await manage.Create(new PostGuestDto(guestEntity3));

            var response = await manage.Read();

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.EqualTo(3));
                Assert.That(response.ToList().Find(x => x.Id == guestDto1.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == guestDto2.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == guestDto3.Id), Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldReadByIdGuests()
        {
            var g1 = await manage.Create(new PostGuestDto(guest1));
            var g2 = await manage.Create(new PostGuestDto(guest2));
            var g3 = await manage.Create(new PostGuestDto(guest3));

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
        public async Task ShouldReadByEmailGuests()
        {
            await manage.Create(new PostGuestDto(guest1));
            await manage.Create(new PostGuestDto(guest2));
            await manage.Create(new PostGuestDto(guest3));

            var response1 = await manage.ReadByEmail(guest1.Email);
            var response2 = await manage.ReadByEmail(guest2.Email);
            var response3 = await manage.ReadByEmail(guest3.Email);

            Assert.Multiple(() =>
            {
                Assert.That(response1, Is.Not.Null);
                Assert.That(response2, Is.Not.Null);
                Assert.That(response3, Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldSearchByEmailGuests()
        {
            await manage.Create(new PostGuestDto(guest1));
            await manage.Create(new PostGuestDto(guest2));
            await manage.Create(new PostGuestDto(guest3));

            var response1 = await manage.SearchByEmail(guest1.Email.Split("@")[0]);
            var response2 = await manage.SearchByEmail(guest2.Email.Split("@")[0]);
            var response3 = await manage.SearchByEmail(guest3.Email.Split("@")[0]);

            Assert.Multiple(() =>
            {
                Assert.That(response1, Is.Not.Null);
                Assert.That(response2, Is.Not.Null);
                Assert.That(response3, Is.Not.Null); 
                Assert.That(response1.Count(), Is.GreaterThan(0));
                Assert.That(response2.Count(), Is.GreaterThan(0));
                Assert.That(response3.Count(), Is.GreaterThan(0));
                Assert.That(response1.ToList().Find(g => g.Email == guest1.Email), Is.Not.Null);
                Assert.That(response2.ToList().Find(g => g.Email == guest2.Email), Is.Not.Null);
                Assert.That(response3.ToList().Find(g => g.Email == guest3.Email), Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldSearchByNameGuests()
        {
            await manage.Create(new PostGuestDto(guest1));
            await manage.Create(new PostGuestDto(guest2));
            await manage.Create(new PostGuestDto(guest3));

            var response1 = await manage.SearchByName(guest1.FirstName[..3]);
            var response2 = await manage.SearchByName(guest2.FirstName[..3]);
            var response3 = await manage.SearchByName(guest3.FirstName[..3]);

            Assert.Multiple(() =>
            {
                Assert.That(response1, Is.Not.Null);
                Assert.That(response2, Is.Not.Null);
                Assert.That(response3, Is.Not.Null);
                Assert.That(response1.Count(), Is.GreaterThan(0));
                Assert.That(response2.Count(), Is.GreaterThan(0));
                Assert.That(response3.Count(), Is.GreaterThan(0));
                Assert.That(response1.ToList().Find(g => g.FirstName == guest1.FirstName), Is.Not.Null);
                Assert.That(response2.ToList().Find(g => g.FirstName == guest2.FirstName), Is.Not.Null);
                Assert.That(response3.ToList().Find(g => g.FirstName == guest3.FirstName), Is.Not.Null);
            });
        }

        [Test]
        public async Task ShouldUpdateGuests()
        {
            var created1 = await manage.Create(new PostGuestDto(guest1));
            var created2 = await manage.Create(new PostGuestDto(guest2));
            var created3 = await manage.Create(new PostGuestDto(guest3));

            var update1 = GuestFixture.GetValidPutGuest(created1.Id);
            var update2 = GuestFixture.GetValidPutGuest(created2.Id);
            var update3 = GuestFixture.GetValidPutGuest(created3.Id);

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
                Assert.That(updated1.Email, Is.Not.EqualTo(created1.Email));
                Assert.That(updated2.Email, Is.Not.EqualTo(created2.Email));
                Assert.That(updated3.Email, Is.Not.EqualTo(created3.Email));
            });
        }

        [Test]
        public async Task ShouldDeleteGuests()
        {
            var created1 = await manage.Create(new PostGuestDto(guest1));
            var created2 = await manage.Create(new PostGuestDto(guest2));
            var created3 = await manage.Create(new PostGuestDto(guest3));

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
        public async Task ShouldNotDeleteGuests()
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
        public async Task ShouldNotReadByInvalidIdGuests()
        {
            var response = await manage.Read(1);

            Assert.That(response, Is.Null);
        }

        [Test]
        public async Task ShouldNotReadByInvalidEmailGuests()
        {
            try
            {
                var response = await manage.ReadByEmail(GuestFixture.GetEmail());
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors.Count, Is.GreaterThan(0));
            }

        }

        [Test]
        public async Task ShouldNotSearchByInvalidEmailGuests()
        {
            var response = await manage.SearchByEmail(GuestFixture.GetEmail().Split("@")[0]);
            Assert.That(response.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task ShouldNotSearchByInvalidNameGuests()
        {
            var response = await manage.SearchByName("xxxxxxxxxx");
            Assert.That(response.Count, Is.EqualTo(0));
        }
    }
}