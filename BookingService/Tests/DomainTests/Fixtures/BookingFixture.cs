using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;
using Application.Bookings.Dtos;

namespace HotelBookingTest.Fixtures
{
    internal enum InvalidBooking
    {
        Null,
        NullStatus,
        IsNotStatus,
        NullRoom,
        InvalidRoom,
        EmptyRoom,
        NullGuest,
        InvalidGuest,
        EmptyGuest
    }

    internal class BookingFixture : Fixture
    {
        public static Booking GetValidBooking(long id = 0)
        {
            return new Booking(id > 0 ? id : GetId(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3), DateTime.UtcNow.AddDays(10), BookingStatus.Created, 1, 1);
        }

        public static PostBookingDto GetValidPostBooking()
        {
            return new PostBookingDto(GetValidBooking());
        }

        public static PutBookingDto GetValidPutBooking(long id = 0)
        {
            return new PutBookingDto(GetValidBooking(id));
        }

        public static List<Booking> GetValidListBookings(int limit = 5)
        {

            var list = new List<Booking>();

            for (int i = 0; i < limit; i++)
            {
                list.Add(GetValidBooking());
            }

            return list;
        }

        public static Booking GetInvalidBooking(InvalidBooking invalid)
        {
            var room = GetValidBooking();

            switch (invalid)
            {
                case InvalidBooking.Null:
                    room = null;
                    break;
                case InvalidBooking.NullRoom:
                    room.RoomId = 0;
                    break;
                case InvalidBooking.NullGuest:
                    room.GuestId = 0;
                    break;
                case InvalidBooking.InvalidRoom:
                    room.RoomId = GetNumber(-1000, 0);
                    break;
                case InvalidBooking.InvalidGuest:
                    room.RoomId = GetNumber(-1000, 0);
                    break;
                case InvalidBooking.EmptyRoom:
                    room.RoomId = 0;
                    break;
                case InvalidBooking.EmptyGuest:
                    room.RoomId = 0;
                    break;
                default:
                    break;
            }

            return room;
        }

        public static decimal CalcularParcela(decimal gasto)
        {
            int parcela;
            
            if (gasto < 50)
                parcela = 1;
            else if (gasto > 500)
                parcela = 10;
            else
                parcela = (int)gasto / 50;

            decimal valor = gasto / parcela;
            
            return valor;
        }

    }
}