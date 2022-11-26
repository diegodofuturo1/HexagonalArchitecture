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
                .WithMessage(GuestValidatorMessages.Null);

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage(GuestValidatorMessages.NullFirstName)

                .NotEmpty()
                .WithMessage(GuestValidatorMessages.EmptyFirstName)

                .MinimumLength(3)
                .WithMessage(GuestValidatorMessages.ShortFirstName)

                .MaximumLength(80)
                .WithMessage(GuestValidatorMessages.LongFirstName);

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage(GuestValidatorMessages.NullLastName)

                .NotEmpty()
                .WithMessage(GuestValidatorMessages.EmptyLastName)

                .MinimumLength(3)
                .WithMessage(GuestValidatorMessages.ShortLastName)

                .MaximumLength(80)
                .WithMessage(GuestValidatorMessages.LongLastName);

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(GuestValidatorMessages.NullEmail)

                .NotEmpty()
                .WithMessage(GuestValidatorMessages.EmptyEmail)

                .MinimumLength(10)
                .WithMessage(GuestValidatorMessages.ShortEmail)

                .MaximumLength(180)
                .WithMessage(GuestValidatorMessages.LongEmail)

                .EmailAddress()
                .WithMessage(GuestValidatorMessages.InvalidEmail);

            RuleFor(x => x.Document.DocumentId)
                .NotNull()
                .WithMessage(GuestValidatorMessages.NullDocumentId)

                .NotEmpty()
                .WithMessage(GuestValidatorMessages.EmptyDocumentId)

                .MinimumLength(5)
                .WithMessage(GuestValidatorMessages.ShortDocumentId)

                .MaximumLength(20)
                .WithMessage(GuestValidatorMessages.LongDocumentId);

            RuleFor(x => x.Document.DocumentType)
                .NotNull()
                .WithMessage(GuestValidatorMessages.NullDocumentType)

                .NotEmpty()
                .WithMessage(GuestValidatorMessages.EmptyDocumentType)

                .IsInEnum()
                .WithMessage(GuestValidatorMessages.InvalidDocumentType);
        }
    }
}
