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

        private readonly Room room1 = RoomFixture.GetValidRoom();
        private readonly Room room2 = RoomFixture.GetValidRoom();
        private readonly Room room3 = RoomFixture.GetValidRoom();

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
            var roomEntity1 = RoomFixture.GetValidRoom();
            var roomEntity2 = RoomFixture.GetValidRoom();
            var roomEntity3 = RoomFixture.GetValidRoom();

            var roomDto1 = await manage.Create(new PostRoomDto(roomEntity1));
            var roomDto2 = await manage.Create(new PostRoomDto(roomEntity2));
            var roomDto3 = await manage.Create(new PostRoomDto(roomEntity3));

            var response = await manage.Read();

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Count(), Is.EqualTo(3));
                Assert.That(response.ToList().Find(x => x.Id == roomDto1.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == roomDto2.Id), Is.Not.Null);
                Assert.That(response.ToList().Find(x => x.Id == roomDto3.Id), Is.Not.Null);
            });
        }


        [Test]
        public async Task ShouldReadByIdRooms()
        {
            var g1 = await manage.Create(new PostRoomDto(room1));
            var g2 = await manage.Create(new PostRoomDto(room2));
            var g3 = await manage.Create(new PostRoomDto(room3));

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
        public async Task ShouldUpdateRooms()
        {
            var created1 = await manage.Create(new PostRoomDto(room1));
            var created2 = await manage.Create(new PostRoomDto(room2));
            var created3 = await manage.Create(new PostRoomDto(room3));

            var update1 = RoomFixture.GetValidPutRoom(created1.Id);
            var update2 = RoomFixture.GetValidPutRoom(created2.Id);
            var update3 = RoomFixture.GetValidPutRoom(created3.Id);

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
                Assert.That(updated1.Name, Is.Not.EqualTo(created1.Name));
                Assert.That(updated2.Name, Is.Not.EqualTo(created2.Name));
                Assert.That(updated3.Name, Is.Not.EqualTo(created3.Name));
            });
        }

        [Test]
        public async Task ShouldDeleteRooms()
        {
            var created1 = await manage.Create(new PostRoomDto(room1));
            var created2 = await manage.Create(new PostRoomDto(room2));
            var created3 = await manage.Create(new PostRoomDto(room3));

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
            var response = await manage.Read(1);

            Assert.That(response, Is.Null);
        }
    }
}