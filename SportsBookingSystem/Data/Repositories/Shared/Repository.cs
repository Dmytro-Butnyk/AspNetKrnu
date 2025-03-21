using Domain.Interfaces.DbRepositoryInterfaces.Shared;
using Domain.Models.DbModels.Shared;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Shared;

/// <summary>
/// General repository (Generic), needed for querying for each entity
/// </summary>
/// <param name="context"></param>
/// <typeparam name="T"></typeparam>
public class Repository<T>
    (SportsBookDbContext context)
    : IRepository<T> where T : BaseModel
{
    protected virtual IQueryable<T> ApplyIncludes(IQueryable<T> dbSet)
    {
        return dbSet;
    }
    
    public async Task<T?> GetByIdAsync(long id, CancellationToken ct)
    {
        DbSet<T> dbSet = context.Set<T>();
        IQueryable<T> query = ApplyIncludes(dbSet);

        return await query
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task AddAsync(T entity, CancellationToken ct)
    {
        DbSet<T> dbSet = context.Set<T>();
        IQueryable<T> query = ApplyIncludes(dbSet);
        
        await dbSet.AddAsync(entity, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(T entity, Action updateAction, CancellationToken ct)
    {
        DbSet<T> dbSet = context.Set<T>();
        IQueryable<T> query = ApplyIncludes(dbSet);
        
        dbSet.Update(entity);
        updateAction();
        
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(T entity, CancellationToken ct)
    {
        DbSet<T> dbSet = context.Set<T>();
        IQueryable<T> query = ApplyIncludes(dbSet);
        
        dbSet.Remove(entity);
        await context.SaveChangesAsync(ct);
    }
}