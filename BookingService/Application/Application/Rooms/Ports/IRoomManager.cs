using Application.Rooms.Dtos;

namespace Application.Rooms.Ports
{
    public interface IRoomManager: IBaseManager<RoomDto, PostRoomDto, PutRoomDto>
    {
    }
}
