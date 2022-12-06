using Domain.Ports;
using Domain.Entities;
using Domain.Exceptions;
using Application.Exceptions;
using Application.Bookings.Dtos;
using Application.Bookings.Ports;

namespace Application.Bookings.Managers
{
    public class BookingManager : IBookingManager
    {
        private IBookingRepository Repository { get; set; }
        private IGuestRepository GuestRepository { get; set; }
        private IRoomRepository RoomRepository { get; set; }

        public BookingManager(IBookingRepository repository, IGuestRepository guestRepository, IRoomRepository roomRepository)
        {
            Repository = repository;
            GuestRepository = guestRepository;
            RoomRepository = roomRepository;
        }

        public async Task<BookingDto> Create(PostBookingDto model)
        {
            var entity = model.ToEntity();

            if (!entity.Validate())
                throw new DomainException(entity.Errors);

            await IsValid(entity);

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

            var dto = new BookingDto(entity);

            return await LoadAdditionalInfo(dto);
        }

        private async Task<BookingDto> LoadAdditionalInfo(BookingDto dto)
        {
            dto.Guest = await GuestRepository.Select(dto.Guest.Id);
            dto.Room = await RoomRepository.Select(dto.Room.Id);

            return dto;
        }

        public async Task<IEnumerable<BookingDto>> Read()
        {
            var entities = await Repository.Select();

            var dtos = BookingDto.ToList(entities).Select(async dto => await LoadAdditionalInfo(dto));

            return dtos.Select(dto => dto.Result);
        }

        public async Task<BookingDto> Update(PutBookingDto model)
        {
            var entiity = model.ToEntity();

            if (!entiity.Validate())
                throw new DomainException(entiity.Errors);

            var result = await Repository.Update(entiity);

            return new BookingDto(result);
        }

        private async Task<bool> IsValid(Booking entity)
        {
            var errors = new List<string>();
            var guestExists = await RoomRepository.Exists(entity.GuestId);
            var roomExists = await RoomRepository.Exists(entity.RoomId);

            if (!guestExists)
                errors.Add("Hóspede não encontrado!");
            
            if (!roomExists)
                errors.Add("Quarto não encontrado!");

            if (errors.Count > 0)
                throw new ManagerException(errors); 

            return true;
        }
    }
}
