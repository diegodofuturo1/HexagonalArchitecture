using Domain.Ports;
using Domain.Exceptions;
using Application.Rooms.Dtos;
using Application.Rooms.Ports;

namespace Application.Rooms.Manages
{
    public class RoomManager : IRoomManager
    {
        private IRoomRepository Repository { get; set; }

        public RoomManager(IRoomRepository repository)
        {
            Repository = repository;
        }

        public async Task<RoomDto> Delete(long id)
        {
            var entity = await Repository.Delete(id);

            return new RoomDto(entity);
        }

        public async Task<RoomDto> Read(long id)
        {
            var entity = await Repository.Select(id);

            if (entity == null)
                return null;

            return new RoomDto(entity);
        }

        public async Task<IEnumerable<RoomDto>> Read()
        {
            var entities = await Repository.Select();

            return RoomDto.ToList(entities);
        }

        public async Task<RoomDto> Create(PostRoomDto model)
        {
            var entity = model.ToEntity();

            if (!entity.IsValid)
                throw new DomainException(entity.Errors);

            var result = await Repository.Insert(entity);

            return new RoomDto(result);
        }

        public async Task<RoomDto> Update(PutRoomDto model)
        {
            var entity = model.ToEntity();

            if (!entity.IsValid)
                throw new DomainException(entity.Errors);

            var result = await Repository.Update(entity);

            return new RoomDto(result);
        }
    }
}
