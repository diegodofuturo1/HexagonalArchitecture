using Domain.Emuns;
using Domain.Validators;

namespace Domain.Entities
{
    public class Booking : Entity
    {
        public DateTime PlaceAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public BookingStatus Status { get; private set; } = BookingStatus.Created;
        public Room Room { get; set; }
        public Guest Guest { get; set; }

        public Booking()
        {
        }

        public Booking(long id)
        {
            Id = id;
        }

        public Booking(DateTime placeAt, DateTime start, DateTime end, BookingStatus status, Room room, Guest guest)
        {
            PlaceAt = placeAt;
            Start = start;
            End = end;
            Status = status;
            Room = room;
            Guest = guest;
        }

        public Booking(long id, DateTime placeAt, DateTime start, DateTime end, BookingStatus status, Room room, Guest guest)
        {
            Id = id;
            PlaceAt = placeAt;
            Start = start;
            End = end;
            Status = status;
            Room = room;
            Guest = guest;
        }

        public void ChangeStatus(BookingAction action)
        {
            Status = (Status, action) switch
            {
                (BookingStatus.Created, BookingAction.Pay) => BookingStatus.Paid,
                (BookingStatus.Created, BookingAction.Cancel) => BookingStatus.Canceled,
                (BookingStatus.Paid, BookingAction.Finish) => BookingStatus.Finished,
                (BookingStatus.Paid, BookingAction.Refound) => BookingStatus.Refounded,
                (BookingStatus.Canceled, BookingAction.Reopen) => BookingStatus.Created,
                _ => Status
            };
        }

        public bool Validate() => Validate(new BookingValidator(), this);
    }
}
