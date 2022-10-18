using OrderManagerCore.Common.Models;

namespace OrderMangerCore.BLL.Services.Interfaces;

public interface IOrderService
{
    int OrdersCount { get; }
    Task<IEnumerable<OrderViewModel>> GetAllAsync();
    Task<IEnumerable<OrderViewModel>> GetPageAsync(int page, int ordersPerPage);
    Task<OrderViewModel> GetByIdAsync(int id);
    Task<IEnumerable<OrderViewModel>> SearchOrdersAsync(string query);
    Task<OrderViewModel> UpdateAsync(int id, OrderViewModel orderViewModel);
    Task DeleteAsync(int id);
    Task<IEnumerable<OrderViewModel>> GetSearchPageAsync(string query, int page, int ordersPerPage);
}