using Domain.Emuns;

namespace Domain.Entities
{
    internal class Booking: Entity
    {
        public DateTime PlaceAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public BookingStatus Status { get; set; }
    }
}
