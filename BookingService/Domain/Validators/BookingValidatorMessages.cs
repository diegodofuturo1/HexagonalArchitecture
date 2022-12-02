using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public static class BookingValidatorMessages
    {
        public static readonly string Null = "A entidade não pode estar nula.";
        public static readonly string NullStatus = "O status não pode estar nulo.";
        public static readonly string IsNotAStatus = "O status informado não existe.";
        public static readonly string NullRoom = "O aluguel informado não tem um quarto.";
        public static readonly string InvalidRoom = "O aluguel informado não tem um quarto válido.";
        public static readonly string NullGuest = "O aluguel informado não tem um hóspede.";
        public static readonly string InvalidGuest = "O aluguel informado não tem um hóspede válido.";
    }
}
