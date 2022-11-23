using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace Application.Dtos
{
    public class PostGuestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }
        public int? DocumentType { get; set; }

        public PostGuestDto()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            DocumentId = string.Empty;
            DocumentType = 3;
        }

        [JsonConstructor]
        public PostGuestDto(string firstName, string lastName, string email, string documentId, int documentType)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DocumentId = documentId;
            DocumentType = documentType;
        }

        public PostGuestDto(Guest guest)
        {
            FirstName = guest.FirstName;
            LastName = guest.LastName;
            Email = guest.Email;
            DocumentId = guest.Document.DocumentId;
            DocumentType = (int)guest.Document.DocumentType;
        }

        public Guest ToEntity()
        {
            return new Guest(FirstName, LastName, Email, new PersonId(DocumentId, (DocumentType)DocumentType));
        }
    }
}
