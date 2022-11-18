using Application.Dtos;

namespace Application.Ports
{
    public interface IGuestManage: IModelManage<GuestDto, PostGuestDto, PutGuestDto>
    {
    }
}
