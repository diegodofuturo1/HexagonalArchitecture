using Domain.Emuns;
using Domain.Entities;

namespace HotelBookingTest.Tests
{
    public class BookingStateTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldStartWithCreatedStatus()
        {
            var booking = new Booking();
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Created));
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Paid));
        }

        [Test]
        public void ShouldSetStatusToCanceledWhenCancelingABookingWithCreatedStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Cancel);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Canceled));
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Finish);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Finished));
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingABookingWithPaidStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Refound);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Refounded));
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningABookingWithCanceldStatus()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Cancel);
            booking.ChangeStatus(BookingAction.Reopen);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Created));
        }

        [Test]
        public void ShouldNotSetStatusToFinishedWhenIsCreated()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Finish);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Created));
        }

        [Test]
        public void ShouldNotSetStatusToRefoundedWhenIsCreated()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Refound);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Created));
        }

        [Test]
        public void ShouldNotSetStatusToCanceledWhenIsPaid()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Cancel);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Paid));
        }

        [Test]
        public void ShouldNotSetStatusToCreatedWhenIsPaid()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Reopen);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Paid));
        }

        [Test]
        public void ShouldNotSetStatusToPaidWhenIsCanceled()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Cancel);
            booking.ChangeStatus(BookingAction.Pay);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Canceled));
        }


        [Test]
        public void ShouldNotSetStatusToFinishedWhenIsCanceled()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Cancel);
            booking.ChangeStatus(BookingAction.Finish);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Canceled));
        }

        [Test]
        public void ShouldNotSetStatusToRefoundedWhenIsCanceled()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Cancel);
            booking.ChangeStatus(BookingAction.Refound);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Canceled));
        }

        [Test]
        public void ShouldNotSetStatusToPaidStatusWhenStatusIsFinished()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Finish);
            booking.ChangeStatus(BookingAction.Pay);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Finished));
        }

        [Test]
        public void ShouldNotSetStatusToCanceledStatusWhenStatusIsFinished()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Finish);
            booking.ChangeStatus(BookingAction.Cancel);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Finished));
        }

        [Test]
        public void ShouldNotSetStatusToRefoundedStatusWhenStatusIsFinished()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Finish);
            booking.ChangeStatus(BookingAction.Refound);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Finished));
        }

        [Test]
        public void ShouldNotSetStatusToCreatedStatusWhenStatusIsFinished()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Finish);
            booking.ChangeStatus(BookingAction.Reopen);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Finished));
        }

        [Test]
        public void ShouldNotSetStatusToPaidedWhenStatusIsRefounded()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Refound);
            booking.ChangeStatus(BookingAction.Pay);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Refounded));
        }


        [Test]
        public void ShouldNotSetStatusToCanceledWhenStatusIsRefounded()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Refound);
            booking.ChangeStatus(BookingAction.Cancel);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Refounded));
        }


        [Test]
        public void ShouldNotSetStatusToFinishedWhenStatusIsRefounded()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Refound);
            booking.ChangeStatus(BookingAction.Finish);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Refounded));
        }

        [Test]
        public void ShouldNotSetStatusToCreatedWhenStatusIsRefounded()
        {
            var booking = new Booking();
            booking.ChangeStatus(BookingAction.Pay);
            booking.ChangeStatus(BookingAction.Refound);
            booking.ChangeStatus(BookingAction.Reopen);
            Assert.That(booking.Status, Is.EqualTo(BookingStatus.Refounded));
        }
    }
}