using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Guests.Dtos
{
    public class PutGuestDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }
        public int DocumentType { get; set; }

        public PutGuestDto()
        {

        }

        public PutGuestDto(long id, string firstName, string lastName, string email, string documentId, int documentType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DocumentId = documentId;
            DocumentType = documentType;
        }

        public PutGuestDto(Guest guest)
        {
            Id = guest.Id;
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            Email = guest.Email;
            DocumentId = guest.Document.DocumentId;
            DocumentType = (int)guest.Document.DocumentType;
        }

        public Guest ToEntity()
        {
            return new Guest(Id, FirstName, LastName, Email, new PersonId(DocumentId, (DocumentType)DocumentType));
        }
    }
}
