using Domain.Ports;
using Application.Dtos;
using Application.Ports;
using Domain.Exceptions;

namespace Application.Manages
{
    public class GuestManage : IGuestManage
    {
        private IGuestRepository Repository { get; set; }

        public GuestManage(IGuestRepository repository)
        {
            Repository = repository;
        }

        public async Task<GuestDto> Delete(long id)
        {
            var entity = await Repository.Delete(id);

            return new GuestDto(entity);
        }

        public async Task<GuestDto> Read(long id)
        {
            var entity = await Repository.Select(id);

            if (entity == null)
                return null;

            return new GuestDto(entity);
        }

        public async Task<IEnumerable<GuestDto>> Read()
        {
            var entities = await Repository.Select();

            return GuestDto.ToList(entities);
        }

        public async Task<GuestDto> Create(PostGuestDto model)
        {
            var entity = model.ToEntity();

            if (!entity.IsValid)
                throw new DomainException(entity.Errors);

            var result = await Repository.Insert(entity);

            return new GuestDto(result);
        }

        public async Task<GuestDto> Update(PutGuestDto model)
        {
            var entity = model.ToEntity();

            if (!entity.IsValid)
                throw new DomainException(entity.Errors);

            var result = await Repository.Update(entity);

            return new GuestDto(result);
        }

        public async Task<GuestDto> ReadByEmail(string email)
        {
            var entity = await Repository.GetByEmail(email);

            if (entity == null)
                throw new DomainException("Não foi possível encontrar um hospede com esse email");

            return new GuestDto(entity);
        }

        public async Task<IEnumerable<GuestDto>> SearchByEmail(string email)
        {
            var entities = await Repository.SearchByEmail(email);

            return GuestDto.ToList(entities);
        }

        public async Task<IEnumerable<GuestDto>> SearchByName(string name)
        {
            var entities = await Repository.SearchByName(name);

            return GuestDto.ToList(entities);
        }
    }
}
