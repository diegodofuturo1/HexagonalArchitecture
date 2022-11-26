using Domain.Emuns;
using Domain.Entities;
using Domain.ValueObjects;
using Application.Guests.Dtos;

namespace HotelBookingTest.Fixtures
{
    internal enum InvalidGuest
    {
        Null, 
        NullFirstName, 
        EmptyFirstName, 
        ShortFirstName, 
        LongFirstName,
        NullLastName,
        EmptyLastName,
        ShortLastName,
        LongLastName,
        NullEmail,
        EmptyEmail,
        ShortEmail,
        LongEmail,
        InvalidEmail,
        NullDocumentId,
        EmptyDocumentId,
        ShortDocumentId,
        LongDocumentId,
        InvalidDocumentType
    }

    internal class GuestFixture: Fixture
    {
        public static Guest GetValidGuest(long id = 0)
        {
            return new Guest(id > 0 ? id : GetId(), GetName(), GetPassword(), GetEmail(), new PersonId(GetCpf(), DocumentType.Cpf));
        }

        public static PostGuestDto GetValidPostGuest()
        {
            return new PostGuestDto(GetValidGuest());
        }

        public static PutGuestDto GetValidPutGuest(long id = 0)
        {
            return new PutGuestDto(GetValidGuest(id));
        }

        public static List<Guest> GetValidListGuests(int limit = 5)
        {

            var list = new List<Guest>();

            for (int i = 0; i < limit; i++)
            {
                list.Add(GetValidGuest());
            }

            return list;
        }

        public static Guest GetInvalidGuest(InvalidGuest invalid)
        {
            var guest = GetValidGuest();

            switch (invalid)
            {
                case InvalidGuest.Null:
                    guest = null;
                    break;
                case InvalidGuest.NullFirstName:
                    guest.FirstName = null;
                    break;
                case InvalidGuest.EmptyFirstName:
                    guest.FirstName = string.Empty;
                    break;
                case InvalidGuest.ShortFirstName:
                    guest.FirstName = GetString(2);
                    break;
                case InvalidGuest.LongFirstName:
                    guest.FirstName = GetString(81);
                    break;
                case InvalidGuest.NullLastName:
                    guest.LastName = null;
                    break;
                case InvalidGuest.EmptyLastName:
                    guest.LastName = string.Empty;
                    break;
                case InvalidGuest.ShortLastName:
                    guest.LastName = GetString(2);
                    break;
                case InvalidGuest.LongLastName:
                    guest.LastName = GetString(81);
                    break;
                case InvalidGuest.NullEmail:
                    guest.Email = null;
                    break;
                case InvalidGuest.EmptyEmail:
                    guest.Email = string.Empty;
                    break;
                case InvalidGuest.ShortEmail:
                    guest.Email = "d@ema.com";
                    break;
                case InvalidGuest.LongEmail:
                    guest.Email = GetString(81) + "@gmail.com";
                    break;
                case InvalidGuest.InvalidEmail:
                    guest.Email = GetString(20);
                    break;
                case InvalidGuest.NullDocumentId:
                    guest.Document.DocumentId = null;
                    break;
                case InvalidGuest.EmptyDocumentId:
                    guest.Document.DocumentId = string.Empty;
                    break;
                case InvalidGuest.ShortDocumentId:
                    guest.Document.DocumentId = GetString(9);
                    break;
                case InvalidGuest.LongDocumentId:
                    guest.Document.DocumentId = GetString(21);
                    break;
                case InvalidGuest.InvalidDocumentType:
                    guest.Document.DocumentType = (DocumentType)99;
                    break;
                default:
                    break;
            }

            return guest;
        }
    }
}