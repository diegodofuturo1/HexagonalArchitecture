using Domain.Ports;
using Application.Dtos;
using Application.Ports;
using Domain.Exceptions;

namespace Application.Manages
{
    public class GuestManage : IGuestManage
    {
        private IGuestRepository repository { get; set; }

        public GuestManage(IGuestRepository repository)
        {
            this.repository = repository;
        }

        public Task<GuestDto> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<GuestDto> Read(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuestDto>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GuestDto>> Read(string prop, string value)
        {
            throw new NotImplementedException();
        }

        public async Task<GuestDto> Create(PostGuestDto model)
        {
            var entity = model.ToEntity();

            if (!entity.IsValid)
                throw new DomainException(entity.Errors);

            var result = await repository.Insert(entity);

            return new GuestDto(result);
        }

        public Task<GuestDto> Update(long id, PutGuestDto model)
        {
            throw new NotImplementedException();
        }
    }
}
