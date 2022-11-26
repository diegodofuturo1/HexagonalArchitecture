using Domain.Entities;
using HotelBookingTest.Fixtures;

namespace HotelBookingTest.Mocks
{
    internal class RepositoryMock<T> where T : Entity
    {
        private readonly List<T> entitys = new();

        public Task<T> Delete(long id)
        {
            var entity = entitys.Find(entity => entity.Id == id);
            entitys.Remove(entity);
            return Task.FromResult(entity);
        }

        public Task<T> Insert(T entity)
        {
            entity.Id = Fixture.GetId();
            entitys.Add(entity);
            return Task.FromResult(entity);
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

        public Task<T> Update(T entity)
        {
            var update = entitys.Find(register => register.Id == entity.Id);
            return Task.FromResult(entity);
        }
    }
}
