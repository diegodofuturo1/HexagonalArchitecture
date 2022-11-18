using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Guest: Entity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public PersonId Document { get; set; }

        public Guest()
        {
            Document = new PersonId();
        }

        public Guest(string firstName, string lastName, string email, PersonId document)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
        }
        public Guest(long id, string firstName, string lastName, string email, PersonId document)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
        }
    }
}
 