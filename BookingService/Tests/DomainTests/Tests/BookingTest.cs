using Domain.Exceptions;
using Domain.Validators;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Tests
{
    internal class BookingTest
    {
        [Test]
        public void ShouldCreateValidBooking()
        {
            var booking = BookingFixture.GetValidBooking();

            booking.Validate();

            Assert.That(booking.Errors, Is.Empty);
        }


        [Test]
        public void ShouldNotCreateBookingWithNullStatus()
        {
            try
            {
                var booking = BookingFixture.GetInvalidBooking(InvalidBooking.NullStatus);

                booking.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(BookingValidatorMessages.NullStatus));
            }
        }

        [Test]
        public void ShouldNotCreateBookingWhenIsNotStatus()
        {
            try
            {
                var booking = BookingFixture.GetInvalidBooking(InvalidBooking.IsNotStatus);

                booking.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(BookingValidatorMessages.IsNotAStatus));
            }
        }

        [Test]
        public void ShouldNotCreateBookingWhenNullRoom()
        {
            try
            {
                var booking = BookingFixture.GetInvalidBooking(InvalidBooking.EmptyGuest);

                booking.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(BookingValidatorMessages.InvalidGuest));
            }
        }

        [Test]
        public void ShouldNotCreateBookingWhenInvalidRoom()
        {
            try
            {
                var booking = BookingFixture.GetInvalidBooking(InvalidBooking.InvalidRoom);

                booking.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(BookingValidatorMessages.InvalidRoom));
            }
        }

        [Test]
        public void ShouldNotCreateBookingWhenNullGuest()
        {
            try
            {
                var booking = BookingFixture.GetInvalidBooking(InvalidBooking.EmptyGuest);

                booking.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(BookingValidatorMessages.InvalidGuest));
            }
        }

        [Test]
        public void ShouldNotCreateBookingWhenInvalidGuest()
        {
            try
            {
                var booking = BookingFixture.GetInvalidBooking(InvalidBooking.InvalidGuest);

                booking.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(BookingValidatorMessages.InvalidGuest));
            }
        }
    }
}
