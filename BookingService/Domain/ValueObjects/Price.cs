using Domain.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Price
    {
        public double Value { get; set; }
        public AcceptCurrencies Currency { get; set; }
    }
}
