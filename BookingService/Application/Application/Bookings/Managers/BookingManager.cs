using Domain.Ports;
using Domain.Exceptions;
using Application.Bookings.Dtos;
using Application.Bookings.Ports;

namespace Application.Bookings.Managers
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository Repository { get; set; }

        public BookingManager(IBookingRepository repository)
        {
            Repository = repository;
        }

        public async Task<BookingDto> Create(PostBookingDto model)
        {
            var entity = model.ToEntity();

            if (!entity.Validate())
                throw new DomainException(entity.Errors);

            var result = await Repository.Insert(entity);

            return new BookingDto(result);
        }

        public async Task<BookingDto> Delete(long id)
        {
            var entity = await Repository.Delete(id);

            return new BookingDto(entity);
        }

        public async Task<BookingDto> Read(long id)
        {
            var entity = await Repository.Select(id);   

            if (entity == null)
                return null;

            return new BookingDto(entity);
        }

        public async Task<IEnumerable<BookingDto>> Read()
        {
            var entities = await Repository.Select();

            return BookingDto.ToList(entities);
        }

        public async Task<BookingDto> Update(PutBookingDto model)
        {
            var entiity = model.ToEntity();

            if (!entiity.Validate())
                throw new DomainException(entiity.Errors);

            var result = await Repository.Update(entiity);

            return new BookingDto(result);  
        }
    }
}
