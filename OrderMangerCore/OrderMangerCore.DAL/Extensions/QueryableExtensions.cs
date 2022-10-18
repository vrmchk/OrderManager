using Microsoft.EntityFrameworkCore;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.DAL.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<Order> IncludeAllEntities(this IQueryable<Order> orders)
    {
        return orders
            .Include(o => o.OrderDetails)
            .Include(o => o.Customer)
            .Include(o => o.Employee)
            .Include(o => o.ShipperNavigation);
    }
    
    public static IQueryable<Product> IncludeAllEntities(this IQueryable<Product> products)
    {
        return products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Include(p => p.OrderDetails);
    }
}