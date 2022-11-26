using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public static class GuestValidatorMessages
    {
        public static readonly string Null = "A entidade não pode estar vazia!";
        public static readonly string NullFirstName = "O nome não pode ser nulo.";
        public static readonly string EmptyFirstName = "O nome não pode ser vazio.";
        public static readonly string ShortFirstName = "O nome deve ter no mínimo 3 caracteres.";
        public static readonly string LongFirstName = "O nome deve ter no máximo 80 caracteres.";
        public static readonly string NullLastName = "O sobrenome não pode ser nulo.";
        public static readonly string EmptyLastName = "O sobrenome não pode ser vazio.";
        public static readonly string ShortLastName = "O sobrenome deve ter no mínimo 3 caracteres.";
        public static readonly string LongLastName = "O sobrenome deve ter no máximo 80 caracteres.";
        public static readonly string NullEmail = "O email não pode ser nulo.";
        public static readonly string EmptyEmail = "O email não pode ser vazio.";
        public static readonly string ShortEmail = "O email deve ter no mínimo 10 caracteres.";
        public static readonly string LongEmail = "O email deve ter no máximo 180 caracteres.";
        public static readonly string InvalidEmail = "O email informado não é válido.";
        public static readonly string NullDocumentId = "O número do documento não pode ser nulo.";
        public static readonly string EmptyDocumentId = "O número do documento não pode ser vazio.";
        public static readonly string ShortDocumentId = "O número do documento deve ter no mínimo 10 caracteres.";
        public static readonly string LongDocumentId = "O número do documento deve ter no máximo 20 caracteres.";
        public static readonly string NullDocumentType = "Tipo de documento inválido ou não encontrado.";
        public static readonly string EmptyDocumentType = "Tipo de documento inválido ou não encontrado.";
        public static readonly string InvalidDocumentType = "Tipo de documento inválido ou não encontrado.";
    }
}
