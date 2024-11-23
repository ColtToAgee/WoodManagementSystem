using WoodManagementSystem.Domain.Common;

namespace WoodManagementSystem.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<IList<T>> UpdateRangeAsync(IList<T> entities);
        Task HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entities);
    }
}
