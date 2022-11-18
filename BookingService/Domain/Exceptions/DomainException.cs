using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public IReadOnlyCollection<string> Errors { get; set; }

        public DomainException(IReadOnlyCollection<string> errors)
        {
            Errors = errors;
        }
    }
}
