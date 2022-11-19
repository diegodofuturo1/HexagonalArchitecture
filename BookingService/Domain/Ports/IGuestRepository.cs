using Domain.Entities;

namespace Domain.Ports
{
    public interface IGuestRepository: IEntityRepository<Guest>
    {
        Task<Guest> GetByEmail(string email);
        Task<IEnumerable<Guest>> SearchByEmail(string email);
        Task<IEnumerable<Guest>> SearchByName(string name);
    }
}
