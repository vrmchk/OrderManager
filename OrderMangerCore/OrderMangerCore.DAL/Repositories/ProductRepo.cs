using Microsoft.EntityFrameworkCore;
using OrderMangerCore.DAL.Context;
using OrderMangerCore.DAL.Entities;
using OrderMangerCore.DAL.Extensions;
using OrderMangerCore.DAL.Repositories.Base;
using OrderMangerCore.DAL.Repositories.Interfaces;

namespace OrderMangerCore.DAL.Repositories;

public class ProductRepo : BaseRepo<Product, int>, IProductRepo
{
    public ProductRepo(ApplicationDbContext context) : base(context) { }
    internal ProductRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await Table
            .IncludeAllEntities()
            .ToListAsync();
    }

    public override async Task<Product?> FindAsync(int id)
    {
        return await Table
            .Where(p => p.Id == id)
            .IncludeAllEntities()
            .FirstOrDefaultAsync();
    }

    public override async Task<Product?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(p => p.Id == id)
            .IncludeAllEntities()
            .FirstOrDefaultAsync();
    }
}