using Domain.Entities;

namespace Application.Ports
{
    public interface IModelManage<TGet, TPost, TPut>
    {
        Task<TGet> Create(TPost model);
        Task<TGet> Read(long id);
        Task<IEnumerable<TGet>> Read();
        Task<IEnumerable<TGet>> Read(string prop, string value);
        Task<TGet> Update(long id, TPut model);
        Task<TGet> Delete(long id);
    }
}
