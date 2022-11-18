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
            Validate();
        }

        public Guest(string firstName, string lastName, string email, PersonId document)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
            Validate();
        }
        public Guest(long id, string firstName, string lastName, string email, PersonId document)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
            Validate();
        }

        public bool Validate() => Validate(new GuestValidator(), this);
    }
}
