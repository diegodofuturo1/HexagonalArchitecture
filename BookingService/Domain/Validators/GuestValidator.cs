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
                .WithMessage("A entidade não pode estar vazia!");

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("O sobrenome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O sobrenome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O sobrenome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O sobrenome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres.")

                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            RuleFor(x => x.Document.DocumentId)
                .NotNull()
                .WithMessage("O número do documento não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O número do documento não pode ser vazio.")

                .MinimumLength(5)
                .WithMessage("O número do documento deve ter no mínimo 10 caracteres.")

                .MaximumLength(20)
                .WithMessage("O número do documento deve ter no máximo 20 caracteres.");

            RuleFor(x => x.Document.DocumentType)
                .NotNull()
                .WithMessage("O tipo de documento não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O tipo de documento não pode ser vazio.")

                .IsInEnum()
                .WithMessage("Tipo de documento inválido ou não encontrado.");
        }
    }
}
