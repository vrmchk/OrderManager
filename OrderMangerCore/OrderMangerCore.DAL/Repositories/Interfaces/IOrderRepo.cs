using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.DAL.Repositories.Interfaces;

public interface IOrderRepo : IRepo<Order, int>
{
    int FirstId { get; } 
    Task<IEnumerable<Order>> FindByProperty(string query);
    Task<IEnumerable<Order>> FindByCustomer(string query);
    Task<IEnumerable<Order>> FindByShipper(string query);
    Task<IEnumerable<Order>> FindByEmployee(string query);
    Task<IEnumerable<Order>> GetItemsAfter(int id, int count);
}