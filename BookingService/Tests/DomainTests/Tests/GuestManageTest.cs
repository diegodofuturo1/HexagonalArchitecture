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
            var post1 = GuestFixture.GetValidPostGuest();
            var post2 = GuestFixture.GetValidPostGuest();
            var post3 = GuestFixture.GetValidPostGuest();

            var created1 = await manage.Create(post1);
            var created2 = await manage.Create(post1);
            var created3 = await manage.Create(post1);

            var response = await manage.Read();

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.EqualTo(4));
                Assert.That(response.ToList().Find(x => x.Id == created1.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == created2.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == created3.Id), Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldReadByIdGuests()
        {
            var post = GuestFixture.GetValidPostGuest();

            var created = await manage.Create(post);

            var response = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Id, Is.EqualTo(created.Id));
            });
        }

        [Test]
        public async Task ShouldReadByEmailGuests()
        {
            var post = GuestFixture.GetValidPostGuest();

            var created = await manage.Create(post);

            var response = await manage.ReadByEmail(created.Email);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Email, Is.EqualTo(created.Email));
            });
        }


        [Test]
        public async Task ShouldSearchByEmailGuests()
        {
            var post = GuestFixture.GetValidPostGuest();

            var created = await manage.Create(post);

            var response = await manage.SearchByEmail(created.Email.Split("@")[0]);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.GreaterThan(0));
                Assert.That(response.ToList().Find(g => g.Email == created.Email), Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldSearchByNameGuests()
        {
            var post = GuestFixture.GetValidPostGuest();

            var created = await manage.Create(post);

            var response = await manage.SearchByName(created.FirstName[..3]);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.GreaterThan(0));
                Assert.That(response.ToList().Find(g => g.FirstName == created.FirstName), Is.Not.Null);
            });
        }

        [Test]
        public async Task ShouldUpdateGuests()
        {
            var post = GuestFixture.GetValidPostGuest();

            var created = await manage.Create(post);

            var update = GuestFixture.GetValidPutGuest(created.Id);

            await manage.Update(update);

            var updated = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updated, Is.Not.Null);
                Assert.That(updated.Id, Is.EqualTo(created.Id));
                Assert.That(updated.Email, Is.Not.EqualTo(created.Email));
            });
        }

        [Test]
        public async Task ShouldDeleteGuests()
        {
            var post = GuestFixture.GetValidPostGuest();

            var created = await manage.Create(post);

            await manage.Delete(created.Id);

            var response = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Null);
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
            var response = await manage.Read(2);

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
                Assert.Multiple(() => { 
                    Assert.That(exception.Errors, Is.Not.Empty);
                });
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