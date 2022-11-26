using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    internal class GuestValidator : AbstractValidator<Guest>
    {
        public GuestValidator()
        {
            RuleFor(guest => guest)
                .NotEmpty()
                .WithMessage(GuestValidatorMessage.Null);

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(GuestValidatorMessage.NullFirstName)

                .NotEmpty()
                .WithMessage(GuestValidatorMessage.EmptyFirstName)

                .MinimumLength(3)
                .WithMessage(GuestValidatorMessage.ShortFirstName)

                .MaximumLength(80)
                .WithMessage(GuestValidatorMessage.LongFirstName);

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(GuestValidatorMessage.NullLastName)

                .NotEmpty()
                .WithMessage(GuestValidatorMessage.EmptyLastName)

                .MinimumLength(3)
                .WithMessage(GuestValidatorMessage.ShortLastName)

                .MaximumLength(80)
                .WithMessage(GuestValidatorMessage.LongLastName);

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(GuestValidatorMessage.NullEmail)

                .NotEmpty()
                .WithMessage(GuestValidatorMessage.EmptyEmail)

                .MinimumLength(10)
                .WithMessage(GuestValidatorMessage.ShortEmail)

                .MaximumLength(180)
                .WithMessage(GuestValidatorMessage.LongEmail)

                .EmailAddress()
                .WithMessage(GuestValidatorMessage.InvalidEmail);

            RuleFor(x => x.Document.DocumentId)
                .NotNull()
                .WithMessage(GuestValidatorMessage.NullDocumentId)

                .NotEmpty()
                .WithMessage(GuestValidatorMessage.EmptyDocumentId)

                .MinimumLength(5)
                .WithMessage(GuestValidatorMessage.ShortDocumentId)

                .MaximumLength(20)
                .WithMessage(GuestValidatorMessage.LongDocumentId);

            RuleFor(x => x.Document.DocumentType)
                .NotNull()
                .WithMessage(GuestValidatorMessage.NullDocumentType)

                .NotEmpty()
                .WithMessage(GuestValidatorMessage.EmptyDocumentType)

                .IsInEnum()
                .WithMessage(GuestValidatorMessage.InvalidDocumentType);
        }
    }
}
