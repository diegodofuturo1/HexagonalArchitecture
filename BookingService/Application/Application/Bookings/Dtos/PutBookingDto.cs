using Domain.Emuns;
using Domain.Entities;

namespace Application.Bookings.Dtos
{
    public class PutBookingDto
    {
        public long Id { get; set; }
        public DateTime PlaceAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public BookingStatus Status { get; private set; } = BookingStatus.Created;
        public long RoomId { get; set; }
        public long GuestId { get; set; }

        public PutBookingDto()
        {

        }

        public PutBookingDto(DateTime placeAt, DateTime start, DateTime end, BookingStatus status, long roomId, long guestId)
        {
            PlaceAt = placeAt;
            Start = start;
            End = end;
            Status = status;
            RoomId = roomId;
            GuestId = guestId;
        }

        public PutBookingDto(long id, DateTime placeAt, DateTime start, DateTime end, BookingStatus status, long roomId, long guestId)
        {
            Id = id;
            PlaceAt = placeAt;
            Start = start;
            End = end;
            Status = status;
            RoomId = roomId;
            GuestId = guestId;
        }

        public PutBookingDto(Booking booking)
        {
            Load(booking);
        }

        public PutBookingDto Load(Booking booking)
        {
            Id = booking.Id;
            PlaceAt = booking.PlaceAt;
            Start = booking.Start;
            End = booking.End;
            Status = booking.Status;
            RoomId = booking.Room.Id;
            GuestId = booking.Guest.Id;

            return this;
        }

        public Booking ToEntity()
        {
            return new Booking(Id, PlaceAt, Start, End, Status, new Room(RoomId), new Guest(GuestId));
        }

        public static List<PutBookingDto> ToList(IEnumerable<Booking> bookings)
        {
            if (bookings == default || !bookings.Any())
                return new List<PutBookingDto>();

            return bookings.Select(booking => new PutBookingDto(booking)).ToList();
        }
    }
}
