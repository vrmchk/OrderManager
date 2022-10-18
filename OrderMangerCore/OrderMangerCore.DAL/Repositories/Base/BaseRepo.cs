using Microsoft.EntityFrameworkCore;
using OrderMangerCore.DAL.Context;
using OrderMangerCore.DAL.Entities.Base;
using OrderMangerCore.DAL.Repositories.Interfaces;

namespace OrderMangerCore.DAL.Repositories.Base;

public abstract class BaseRepo<T, TId> : IRepo<T, TId> where T : BaseEntity<TId>, new()
{
    public DbSet<T> Table { get; }
    public ApplicationDbContext Context { get; }

    protected BaseRepo(ApplicationDbContext context)
    {
        Context = context;
        Table = Context.Set<T>();
    }

    protected BaseRepo(DbContextOptions<ApplicationDbContext> options) : this(new ApplicationDbContext(options)) { }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await Table.ToListAsync();

    public virtual async Task<T?> FindAsync(TId id) => await Table.FindAsync(id);

    public virtual async Task<T?> FindAsNoTrackingAsync(TId id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id!.Equals(id));
    }

    public virtual async Task<int> AddAsync(T entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> UpdateAsync(T entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> DeleteAsync(T entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist ? await SaveChangesAsync() : 0;
    }
 
    public virtual async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();
    
    public void Dispose() => Context.Dispose();
    
}