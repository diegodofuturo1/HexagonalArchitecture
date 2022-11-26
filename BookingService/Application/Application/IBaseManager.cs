using Domain.Entities;

namespace Application
{
    public interface IBaseManager<TGet, TPost, TPut>
    {
        Task<TGet> Create(TPost model);
        Task<TGet> Read(long id);
        Task<IEnumerable<TGet>> Read();
        Task<TGet> Update(TPut model);
        Task<TGet> Delete(long id);
    }
}
