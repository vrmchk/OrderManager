using Microsoft.EntityFrameworkCore;
using OrderMangerCore.DAL.Entities.Base;

namespace OrderMangerCore.DAL.Repositories.Interfaces;

public interface IRepo<T, TId> : IDisposable where T : BaseEntity<TId>, new()
{
    DbSet<T> Table { get; }
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> FindAsync(TId id);
    Task<T?> FindAsNoTrackingAsync(TId id);
    Task<int> AddAsync(T entity, bool persist = true);
    Task<int> UpdateAsync(T entity, bool persist = true);
    Task<int> DeleteAsync(T entity, bool persist = true);
    Task<int> SaveChangesAsync();
}