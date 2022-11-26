using Application.Guests.Dtos;

namespace Application.Guests.Ports
{
    public interface IGuestManager : IBaseManager<GuestDto, PostGuestDto, PutGuestDto>
    {
        Task<GuestDto> ReadByEmail(string email);
        Task<IEnumerable<GuestDto>> SearchByEmail(string email);
        Task<IEnumerable<GuestDto>> SearchByName(string name);
    }
}
