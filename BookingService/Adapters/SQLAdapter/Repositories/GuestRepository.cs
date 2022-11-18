using Domain.Ports;
using Domain.Entities;
using SqlAdapter.Contexts;

namespace SqlAdapter.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext context;

        public GuestRepository(HotelDbContext context)
        {
            this.context = context;
        }

        public Task<Guest> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guest> Insert(Guest entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<Guest> Select(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guest>> Select(string prop, string value)
        {
            throw new NotImplementedException();
        }

        public Task<Guest> Update(long id, Guest entity)
        {
            throw new NotImplementedException();
        }
    }
}
