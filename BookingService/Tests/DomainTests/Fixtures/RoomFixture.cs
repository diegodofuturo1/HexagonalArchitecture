using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;
using Application.Rooms.Dtos;

namespace HotelBookingTest.Fixtures
{
    internal enum InvalidRoom
    {
        Null,
        Empty,
        NullName,
        EmptyName,
        ShortName,
        LongName,
        NullLevel,
        MinLevel,
        NullInMaintence,
        NullPriceValue,
        MinPriceValue,
        NullStatus,
        IsNotAPriceAcceptCurrencies
    }

    internal class RoomFixture : Fixture
    {
        public static Room GetValidRoom(long id = 0)
        {
            return new Room(id > 0 ? id : GetId(), GetName(), GetNumber(), false, new Price(GetPrice(), AcceptCurrencies.Real));
        }

        public static PostRoomDto GetValidPostRoom()
        {
            return new PostRoomDto(GetValidRoom());
        }

        public static PutRoomDto GetValidPutRoom(long id = 0)
        {
            return new PutRoomDto(GetValidRoom(id));
        }

        public static List<Room> GetValidListRooms(int limit = 5)
        {

            var list = new List<Room>();

            for (int i = 0; i < limit; i++)
            {
                list.Add(GetValidRoom());
            }

            return list;
        }

        public static Room GetInvalidRoom(InvalidRoom invalid)
        {
            var room = GetValidRoom();

            switch (invalid)
            {
                case InvalidRoom.Null:
                    room = null;
                    break;
                case InvalidRoom.Empty:
                    room = default;
                    break;
                case InvalidRoom.NullName:
                    room.Name = null;
                    break;
                case InvalidRoom.EmptyName:
                    room.Name = String.Empty;
                    break;
                case InvalidRoom.ShortName:
                    room.Name = GetString(2);
                    break;
                case InvalidRoom.LongName:
                    room.Name = GetString(90);
                    break;
                case InvalidRoom.NullLevel:
                    room.Level = 0;
                    break;
                case InvalidRoom.MinLevel:
                    room.Level = GetNumber(-1000, -1);
                    break;
                case InvalidRoom.NullPriceValue:
                    room.Price.Value = 0;
                    break;
                case InvalidRoom.MinPriceValue: 
                    room.Price.Value = GetNumber(-1000, -1); 
                    break;
                case InvalidRoom.NullStatus:
                    room.Price.Currency = (AcceptCurrencies)GetNumber(-1000, -1);
                    break;
                case InvalidRoom.IsNotAPriceAcceptCurrencies:
                    room.Price.Currency = (AcceptCurrencies)999;
                    break;
                default:
                    break;
            }

            return room;
        }
    }
}