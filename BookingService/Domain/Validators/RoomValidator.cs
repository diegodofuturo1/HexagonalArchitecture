using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    internal class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(room => room)
                .NotNull()
                .WithMessage(RoomValidatorMessages.Null);

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(RoomValidatorMessages.NullName)

                .NotEmpty()
                .WithMessage(RoomValidatorMessages.EmptyName)

                .MinimumLength(3)
                .WithMessage(RoomValidatorMessages.ShortName)

                .MaximumLength(80)
                .WithMessage(RoomValidatorMessages.LongName);

            RuleFor(x => x.Level)
                .NotNull()
                .WithMessage(RoomValidatorMessages.NullLevel)

                .GreaterThan(0)
                .WithMessage(RoomValidatorMessages.MinLevel);

            RuleFor(x => x.InMaintence)
                .NotNull()
                .WithMessage(RoomValidatorMessages.NullInMaintence);

            RuleFor(x => x.Price.Value)
                .NotNull()
                .WithMessage(RoomValidatorMessages.NullPriceValue)

                .GreaterThan(0)
                .WithMessage(RoomValidatorMessages.MinPriceValue);

            RuleFor(x => x.Price.Currency)

                .NotEmpty()
                .WithMessage(RoomValidatorMessages.IsNotAPriceAcceptCurrencies)

                .IsInEnum()
                .WithMessage(RoomValidatorMessages.IsNotAPriceAcceptCurrencies);
        }
    }
}
