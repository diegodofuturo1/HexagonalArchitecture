using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    internal class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(BookingValidatorMessages.Null);

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage(BookingValidatorMessages.NullStatus)

                .IsInEnum()
                .WithMessage(BookingValidatorMessages.IsNotAStatus)
;

            RuleFor(x => x.Room.Id)
                .NotNull()
                .WithMessage(BookingValidatorMessages.NullRoom)

                .GreaterThan(0)
                .WithMessage(BookingValidatorMessages.InvalidRoom);

            RuleFor(x => x.Guest.Id)
                .NotNull()
                .WithMessage(BookingValidatorMessages.NullGuest)

                .GreaterThan(0)
                .WithMessage(BookingValidatorMessages.InvalidGuest);
        }
    }
}
