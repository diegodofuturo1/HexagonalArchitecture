using Domain.Exceptions;
using Domain.Validators;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Tests
{
    internal class RoomTest
    {
        [Test]
        public void ShouldCreateValidRoom()
        {
            var room = RoomFixture.GetValidRoom();

            room.Validate();

            Assert.That(room.Errors, Is.Empty);
        }

        [Test]
        public void ShouldNotCreateRoomWithNullName()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.NullName);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.NullName));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithEmptyName()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.EmptyName);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.EmptyName));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithShortName()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.ShortName);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.ShortName));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithLongName()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.LongName);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.LongName));
            }
        }



        [Test]
        public void ShouldNotCreateRoomWithNullLevel()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.NullLevel);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.NullLevel));
            }
        }


        [Test]
        public void ShouldNotCreateRoomWithMinLevel()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.MinLevel);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.MinLevel));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithNullInMaintence()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.NullInMaintence);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.NullInMaintence));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithNullPriceValue()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.NullPriceValue);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.NullPriceValue));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithMinPriceValue()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.MinPriceValue);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.MinPriceValue));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithNullStatus()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.NullStatus);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.NullStatus));
            }
        }

        [Test]
        public void ShouldNotCreateRoomWithIsNotAPriceAcceptCurrencies()
        {
            try
            {
                var room = RoomFixture.GetInvalidRoom(InvalidRoom.IsNotAPriceAcceptCurrencies);

                room.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(RoomValidatorMessages.IsNotAPriceAcceptCurrencies));
            }
        }
    }
}
