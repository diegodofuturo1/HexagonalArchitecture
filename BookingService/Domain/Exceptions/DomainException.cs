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

        public DomainException(string error) : base(error)
        {
            Errors = new List<string>() { error };
        }
        public DomainException(IReadOnlyCollection<string> errors) : base(String.Join(" - ", errors))
        {
            Errors = errors;
        }
    }
}
