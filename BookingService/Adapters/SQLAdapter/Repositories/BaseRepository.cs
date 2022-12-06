using Domain.Ports;
using Domain.Entities;
using SqlAdapter.Contexts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SqlAdapter.Repositories
{
    public class BaseRepository<T>: IEntityRepository<T> where T: Entity
    {
        protected readonly HotelDbContext context;

        public BaseRepository(HotelDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> Insert(T obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Delete(long id)
        {
            var obj = await Select(id);

            if (obj != null)
            {
                context.Remove(obj);
                await context.SaveChangesAsync();
            }

            return obj;
        }

        public virtual async Task<T> Select(long id)
        {
            return await context.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> Select()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> Select(Expression<Func<T, bool>> expression, bool asNoTracking = true)
            => asNoTracking
                ? await BuildQuery(expression).AsNoTracking().FirstOrDefaultAsync()
                : await BuildQuery(expression).FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> expression, bool asNoTracking = true)
            => asNoTracking
                ? await BuildQuery(expression).AsNoTracking().ToListAsync()
                : await BuildQuery(expression).ToListAsync();

        private IQueryable<T> BuildQuery(Expression<Func<T, bool>> expression) => context.Set<T>().Where(expression);

        public async Task<bool> Exists(long id)
        {
            return await Task.FromResult(context.Set<T>().Any(x => x.Id == id));
        }
    }
}
