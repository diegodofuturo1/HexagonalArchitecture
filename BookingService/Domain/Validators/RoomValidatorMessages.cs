namespace Domain.Validators
{
    public static class RoomValidatorMessages
    {
        public static readonly string Null = "A entidade não pode estar nula.";
        public static readonly string Empty = "A entidade não pode estar vazia.";
        public static readonly string NullName = "O nome não pode ser nulo.";
        public static readonly string EmptyName = "O nome não pode ser vazio.";
        public static readonly string ShortName = "O nome deve ter no mínimo 3 caracteres.";
        public static readonly string LongName = "O nome deve ter no máximo 80 caracteres.";
        public static readonly string NullLevel = "O level não pode ser nulo.";
        public static readonly string MinLevel = "O level deve ser maior que zero";
        public static readonly string NullInMaintence = "O 'em manutenção' não pode ser nulo.";
        public static readonly string NullPriceValue = "O preço não pode ser nulo.";
        public static readonly string MinPriceValue = "O preço deve ser maior que zero";
        public static readonly string NullStatus = "A moeda não pode ser nula.";
        public static readonly string IsNotAPriceAcceptCurrencies = "A moeda informada não existe não pode ser nula.";

    }
}
