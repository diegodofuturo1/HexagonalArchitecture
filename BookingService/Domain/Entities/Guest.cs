using Domain.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Guest : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public PersonId Document { get; set; }

        public Guest()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Document = new PersonId();
        }

        public Guest(long id)
        {
            Id = id;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
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

        public bool Validate() => Validate(new GuestValidator(), this);
    }
}
