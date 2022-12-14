using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Guests.Dtos
{
    public class GuestDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }
        public int DocumentType { get; set; }

        public GuestDto()
        {

        }

        public GuestDto(long id, string firstName, string lastName, string email, string documentId, int documentType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DocumentId = documentId;
            DocumentType = documentType;
        }

        public GuestDto(Guest guest)
        {
            Load(guest);    
        }



        public GuestDto Load(Guest guest)
        {
            if (guest == null)
                return default;

            Id = guest.Id;
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            Email = guest.Email;
            DocumentId = guest.Document.DocumentId;
            DocumentType = (int)guest.Document.DocumentType;

            return this;
        }

        public Guest ToEntity()
        {
            return new Guest(Id, FirstName, LastName, Email, new PersonId(DocumentId, (DocumentType)DocumentType));
        }

        public static List<GuestDto> ToList(IEnumerable<Guest> entities)
        {
            if (entities == null || !entities.Any())
                return new List<GuestDto>();

            return entities.Select(entity => new GuestDto(entity)).ToList();
        }

    }
}
