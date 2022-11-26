using Application.Dtos;

namespace Application.Ports
{
    public interface IGuestManage: IBaseManage<GuestDto, PostGuestDto, PutGuestDto>
    {
        Task<GuestDto> ReadByEmail(string email);
        Task<IEnumerable<GuestDto>> SearchByEmail(string email);
        Task<IEnumerable<GuestDto>> SearchByName(string name);
    }
}
