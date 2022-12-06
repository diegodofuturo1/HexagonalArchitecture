using Domain.Entities;
using HotelBookingTest.Mocks;
using Application.Rooms.Dtos;
using Application.Rooms.Ports;
using HotelBookingTest.Fixtures;
using Application.Rooms.Manages;

namespace HotelBookingTest.Tests
{
    internal class RoomManagerTest
    {
        private IRoomManager manage;

        [SetUp]
        public void Setup()
        {
            manage = new RoomManager(new RoomRepositoryMock());
        }

        [Test]
        public async Task ShouldCreateRoom()
        {
            var entity = RoomFixture.GetValidRoom();
            var created = await manage.Create(new PostRoomDto(entity));

            Assert.Multiple(() =>
            {
                Assert.That(created, Is.Not.Null);
                Assert.That(created.Id, Is.Not.LessThanOrEqualTo(0));
            });
        }

        [Test]
        public async Task ShouldReadRooms()
        {
            var post1 = RoomFixture.GetValidPostRoom();
            var post2 = RoomFixture.GetValidPostRoom();
            var post3 = RoomFixture.GetValidPostRoom();

            var created1 = await manage.Create(post1);
            var created2 = await manage.Create(post2);
            var created3 = await manage.Create(post3);

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
        public async Task ShouldReadByIdRooms()
        {
            var post = RoomFixture.GetValidPostRoom();

            var created = await manage.Create(post);

            var response = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Id, Is.EqualTo(created.Id));
            });
        }

        [Test]
        public async Task ShouldUpdateRooms()
        {
            var post = RoomFixture.GetValidPostRoom();

            var created = await manage.Create(post);

            var update = RoomFixture.GetValidPutRoom(created.Id);

            await manage.Update(update);

            var updated = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updated, Is.Not.Null);
                Assert.That(updated.Id, Is.EqualTo(created.Id));
                Assert.That(updated.Name, Is.Not.EqualTo(created.Name));
            });
        }

        [Test]
        public async Task ShouldDeleteRooms()
        {
            var post = RoomFixture.GetValidPostRoom();

            var created = await manage.Create(post);

            await manage.Delete(created.Id);

            var response = await manage.Read(created.Id);

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Null);
            });
        }

        [Test]
        public async Task ShouldNotDeleteRooms()
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
        public async Task ShouldNotReadByInvalidIdRooms()
        {
            var response = await manage.Read(2);

            Assert.That(response, Is.Null);
        }
    }
}