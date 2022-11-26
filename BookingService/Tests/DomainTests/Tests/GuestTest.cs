using Domain.Exceptions;
using Domain.Validators;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Tests
{
    internal class GuestTest
    {
        [Test]
        public void ShouldCreateValidGuest()
        {
            var guest = GuestFixture.GetValidGuest();

            guest.Validate();

            Assert.That(guest.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldNotCreateGuestWithNullFirstName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.NullFirstName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.NullFirstName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithEmptyFirstName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.EmptyFirstName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.EmptyFirstName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithShortFirstName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.ShortFirstName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.ShortFirstName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithLongFirstName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.LongFirstName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.LongFirstName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithNullLastName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.NullLastName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.NullLastName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithEmptyLastName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.EmptyLastName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.EmptyLastName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithShortLastName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.ShortLastName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.ShortLastName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithLongLastName()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.LongLastName);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.LongLastName));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithNullEmail()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.NullEmail);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.NullEmail));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithEmptyEmail()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.EmptyEmail);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.EmptyEmail));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithShortEmail()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.ShortEmail);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.ShortEmail));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithLongEmail()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.LongEmail);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.LongEmail));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithInvalidEmail()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.InvalidEmail);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.InvalidEmail));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithNullDocumentId()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.NullDocumentId);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.NullDocumentId));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithEmptyDocumentId()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.EmptyDocumentId);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.EmptyDocumentId));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithLongDocumentId()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.LongDocumentId);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.LongDocumentId));
            }

        }

        [Test]
        public void ShouldNotCreateGuestWithInvalidDocumentType()
        {
            try
            {
                var guest = GuestFixture.GetInvalidGuest(InvalidGuest.InvalidDocumentType);

                guest.Validate();
            }
            catch (DomainException exception)
            {
                Assert.That(exception.Errors, Does.Contain(GuestValidatorMessages.InvalidDocumentType));
            }

        }
    }
}
