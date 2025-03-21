using Domain.Models.DbModels.Shared;

namespace Domain.Interfaces.DbRepositoryInterfaces.Shared;

public interface IRepository<T> where T : BaseModel
{
        Task<T?> GetByIdAsync(long id, CancellationToken ct);
        Task AddAsync(T entity, CancellationToken ct);
        Task UpdateAsync(T entity, Action updateAction, CancellationToken ct);
        Task DeleteAsync(T entity, CancellationToken ct);
}