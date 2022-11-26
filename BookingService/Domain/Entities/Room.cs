using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Room: Entity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintence { get; set; }
        public Price Price { get; set; }

        public Room()
        {
            Name = string.Empty;
            Price = new Price();
        }

        public Room(long id)
        {
            Id = id;
            Name = string.Empty;
            Price = new Price();
        }

        public Room(string name, int level, bool inMaintence, Price price)
        {
            Name = name;
            Level = level;
            InMaintence = inMaintence;
            Price = price;
        }

        public Room(long id, string name, int level, bool inMaintence, Price price)
        {
            Id = id;
            Name = name;
            Level = level;
            InMaintence = inMaintence;
            Price = price;
        }

        public bool Validate() => Validate(new RoomValidator(), this);
    }
}
