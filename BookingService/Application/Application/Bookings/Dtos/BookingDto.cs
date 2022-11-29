using Domain.Emuns;
using Domain.Entities;

namespace Application.Bookings.Dtos
{
    public class BookingDto
    {
        public long Id { get; set; }
        public DateTime PlaceAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public BookingStatus Status { get; private set; } = BookingStatus.Created;
        public long RoomId { get; set; }
        public long GuestId { get; set; }

        public BookingDto()
        {

        }

        public BookingDto(DateTime placeAt, DateTime start, DateTime end, BookingStatus status, long roomId, long guestId)
        {
            PlaceAt = placeAt;
            Start = start;
            End = end;
            Status = status;
            RoomId = roomId;
            GuestId = guestId;
        }

        public BookingDto(long id, DateTime placeAt, DateTime start, DateTime end, BookingStatus status, long roomId, long guestId)
        {
            Id = id;
            PlaceAt = placeAt;
            Start = start;
            End = end;
            Status = status;
            RoomId = roomId;
            GuestId = guestId;
        }

        public BookingDto(Booking booking)
        {
            Load(booking);
        }

        public BookingDto Load(Booking booking)
        {
            if (booking == null)
                return null;

            Id= booking.Id;
            PlaceAt = booking.PlaceAt;
            Start = booking.Start;
            End = booking.End;
            Status = booking.Status;
            RoomId= booking.Room.Id;
            GuestId = booking.Guest.Id;

            return this;
        }

        public Booking ToEntity() {
            return new Booking(Id, PlaceAt, Start, End, Status, new Room(RoomId), new Guest(GuestId)); 
        }

        public static List<BookingDto> ToList(IEnumerable<Booking> bookings)
        {
            if (bookings == default || !bookings.Any())
                return new List<BookingDto>();

            return bookings.Select(booking => new BookingDto(booking)).ToList();
        }
    }
}
