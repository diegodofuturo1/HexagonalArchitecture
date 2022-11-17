using Domain.Entities;

namespace Domain.Ports
{
    internal interface IEntityRepository<T> where T: Entity
    {
        Task<T> Select(long id);
        Task<IEnumerable<T>> Select();
        Task<IEnumerable<T>> Select(string prop, string value);
        Task<T> Delete(long id);
        Task<T> Insert(T entity);
        Task<T> Update(long id, T entity);
    }
}
