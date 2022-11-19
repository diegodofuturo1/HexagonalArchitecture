using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Ports
{
    public interface IEntityRepository<T> where T: Entity
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(long id);
        Task<T> Select(long id);
        Task<IEnumerable<T>> Select();
        Task<T> Select(Expression<Func<T, bool>> expression, bool asNoTracking = true);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> expression, bool asNoTracking = true);
    }
}
