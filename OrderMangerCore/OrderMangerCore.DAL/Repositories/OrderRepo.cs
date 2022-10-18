using Microsoft.EntityFrameworkCore;
using OrderMangerCore.DAL.Context;
using OrderMangerCore.DAL.Entities;
using OrderMangerCore.DAL.Extensions;
using OrderMangerCore.DAL.Repositories.Base;
using OrderMangerCore.DAL.Repositories.Interfaces;

namespace OrderMangerCore.DAL.Repositories;

public class OrderRepo : BaseRepo<Order, int>, IOrderRepo
{
    public OrderRepo(ApplicationDbContext context) : base(context)
    {
        FirstId = Table.OrderBy(o => o.Id).First().Id;
    }

    internal OrderRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        FirstId = Table.OrderBy(o => o.Id).First().Id;
    }

    public int FirstId { get; }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await Table
            .IncludeAllEntities()
            .ToListAsync();
    }

    public override async Task<Order?> FindAsync(int id)
    {
        return await Table
            .Where(o => o.Id == id)
            .IncludeAllEntities()
            .FirstOrDefaultAsync();
    }

    public override async Task<Order?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(o => o.Id == id)
            .IncludeAllEntities()
            .FirstOrDefaultAsync();
    }


    public async Task<IEnumerable<Order>> GetItemsAfter(int id, int count)
    {
        return await Table
            .OrderBy(o => o.Id)
            .Where(o => o.Id >= id)
            .Take(count)
            .IncludeAllEntities()
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> FindByProperty(string query)
    {
        return await Table
            .Where(o =>
                o.Id.ToString() == query ||
                o.CustomerId == query ||
                o.EmployeeId.ToString() == query ||
                o.ShipperId.ToString() == query ||
                o.ShipName == query ||
                o.ShipRegion == query ||
                o.ShipCountry == query ||
                o.ShipCity == query ||
                o.ShipAddress == query ||
                o.ShipPostalCode == query
            )
            .IncludeAllEntities()
            .ToArrayAsync();
    }


    public async Task<IEnumerable<Order>> FindByCustomer(string query)
    {
        return await Table
            .Include(o => o.Customer)
            .Where(o => o.Customer != null &&
                        (o.Customer.ContactName == query ||
                         o.Customer.CompanyName == query ||
                         o.Customer.ContactTitle == query))
            .Include(o => o.Employee)
            .Include(o => o.ShipperNavigation)
            .Include(o => o.OrderDetails)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> FindByShipper(string query)
    {
        return await Table
            .Include(o => o.ShipperNavigation)
            .Where(o => o.ShipperNavigation != null && o.ShipperNavigation.CompanyName == query)
            .Include(o => o.Customer)
            .Include(o => o.Employee)
            .Include(o => o.OrderDetails)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> FindByEmployee(string query)
    {
        return await Table
            .Include(o => o.Employee)
            .Where(o => o.Employee != null &&
                        (o.Employee.FirstName == query ||
                         o.Employee.LastName == query ||
                         o.Employee.Title == query ||
                         o.Employee.TitleOfCourtesy == query))
            .ToListAsync();
    }
}