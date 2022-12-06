using Domain.Entities;
using Domain.Ports;
using HotelBookingTest.Fixtures;
using System.Linq.Expressions;

namespace HotelBookingTest.Mocks
{
    internal class RepositoryMock<T>: IEntityRepository<T> where T : Entity
    {
        protected readonly List<T> entitys = new();

        public Task<T> Delete(long id)
        {
            var entity = entitys.Find(entity => entity.Id == id);
            entitys.Remove(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> Exists(long id)
        {
            return Task.FromResult(true);
        }

        public Task<T> Insert(T entity)
        {
            entity.Id = Fixture.GetId();
            entitys.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<T>> Search(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> Select(long id)
        {
            var entity = entitys.Find(entity => entity.Id == id);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<T>> Select()
        {
            return Task.FromResult((IEnumerable<T>)entitys);
        }

        public Task<T> Select(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties().ToList();
            var updated = entitys.Find(register => register.Id == entity.Id);

            properties.ForEach(property =>
            {
                try
                {
                    var value = property.GetValue(entity);
                    property.SetValue(updated, value);
                }
                catch { }
            });

            return Task.FromResult(updated);
        }
    }
}
