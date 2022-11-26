using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Rooms.Dtos
{
    public class PostRoomDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintence { get; set; }
        public int PriceCurrency { get; set; }
        public double PriceValue { get; set; }

        public PostRoomDto()
        {
            Name = string.Empty;
        }

        public PostRoomDto(string name, int level, bool inMaintence, int priceCurrency, double priceValue)
        {
            Name = name;
            Level = level;
            InMaintence = inMaintence;
            PriceCurrency = priceCurrency;
            PriceValue = priceValue;
        }

        public PostRoomDto(Room entity)
        {
            Load(entity);
        }

        public PostRoomDto Load(Room room)
        {
            Name = room.Name;
            Level = room.Level;
            InMaintence = room.InMaintence;
            PriceCurrency = (int)room.Price.Currency;
            PriceValue = room.Price.Value;

            return this;
        }

        public Room ToEntity()
        {
            return new Room(Name, Level, InMaintence, new Price(PriceValue, (AcceptCurrencies)PriceCurrency));
        }


        public static List<PostRoomDto> ToList(IEnumerable<Room> entities)
        {
            if (entities == null || !entities.Any())
                return new List<PostRoomDto>();

            return entities.Select(entity => new PostRoomDto(entity)).ToList();
        }
    }
}
