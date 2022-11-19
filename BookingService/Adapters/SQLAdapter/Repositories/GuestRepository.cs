using System;
using Domain.Ports;
using Domain.Entities;
using SqlAdapter.Contexts;
using System.Linq.Expressions;

namespace SqlAdapter.Repositories
{
    public class GuestRepository: BaseRepository<Guest>, IGuestRepository
    {
        public GuestRepository(HotelDbContext context): base(context) { }

        public async Task<Guest> GetByEmail(string email)
        {
            Expression<Func<Guest, bool>> filter = guest => guest.Email.ToLower() == email.ToLower();

            return await Select(filter);
        }

        public async Task<IEnumerable<Guest>> SearchByEmail(string email)
        {
            Expression<Func<Guest, bool>> filter = guest => guest.Email.ToLower().Contains(email.ToLower());

            return await Search(filter);
        }

        public async Task<IEnumerable<Guest>> SearchByName(string name)
        {
            Expression<Func<Guest, bool>> filter = guest => guest.FirstName.ToLower().Contains(name.ToLower());

            return await Search(filter);
        }
    }
}
