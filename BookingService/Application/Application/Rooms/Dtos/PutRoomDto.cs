using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Rooms.Dtos
{
    public class PutRoomDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintence { get; set; }
        public int PriceCurrency { get; set; }
        public double PriceValue { get; set; }

        public PutRoomDto()
        {
            Name = string.Empty;
        }

        public PutRoomDto(string name, int level, bool inMaintence, int priceCurrency, double priceValue)
        {
            Name = name;
            Level = level;
            InMaintence = inMaintence;
            PriceCurrency = priceCurrency;
            PriceValue = priceValue;
        }

        public PutRoomDto(long id, string name, int level, bool inMaintence, int priceCurrency, double priceValue)
        {
            Id = id;
            Name = name;
            Level = level;
            InMaintence = inMaintence;
            PriceCurrency = priceCurrency;
            PriceValue = priceValue;
        }

        public PutRoomDto(Room entity)
        {
            Load(entity);
        }

        public PutRoomDto Load(Room room)
        {
            Id = room.Id;
            Name = room.Name;
            Level = room.Level;
            InMaintence = room.InMaintence;
            PriceCurrency = (int)room.Price.Currency;
            PriceValue = room.Price.Value;

            return this;
        }

        public Room ToEntity()
        {
            return new Room(Id, Name, Level, InMaintence, new Price(PriceValue, (AcceptCurrencies)PriceCurrency));
        }


        public static List<PutRoomDto> ToList(IEnumerable<Room> entities)
        {
            if (entities == null || !entities.Any())
                return new List<PutRoomDto>();

            return entities.Select(entity => new PutRoomDto(entity)).ToList();
        }
    }
}
