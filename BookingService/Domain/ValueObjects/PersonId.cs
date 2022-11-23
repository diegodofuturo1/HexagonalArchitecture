using Domain.Emuns;

namespace Domain.ValueObjects
{
    public class PersonId
    {
        public string DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }

        public PersonId()
        {
            DocumentId = "";
            DocumentType = DocumentType.Cpf;
        }

        public PersonId(string documentId, DocumentType documentType)
        {
            DocumentId = documentId;
            DocumentType = documentType;
        }
    }
}
