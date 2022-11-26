using Domain.Emuns;

namespace Domain.ValueObjects
{
    public class Price
    {
        public double Value { get; set; }
        public AcceptCurrencies Currency { get; set; }

        public Price()
        {

        }

        public Price(double value, AcceptCurrencies currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
