using FluentValidation;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }

        internal List<string> errors = new();

        public bool IsValid => errors.Count == 0;

        public IReadOnlyCollection<string> Errors => errors;

        protected bool Validate<T, J>(T validator, J obj) where T : AbstractValidator<J>
        {
            errors.Clear();

            var validation = validator.Validate(obj);

            if (validation.Errors.Count > 0)
                foreach (var error in validation.Errors)
                    errors.Add(error.ErrorMessage);

            return errors.Count == 0;
        }

        public string ErrorsToString()
        {
            return String.Join("\n", errors);
        }
    }
}
