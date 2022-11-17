using Domain.Emuns;

namespace Domain.ValueObjects
{
    public class PersonId
    {
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
