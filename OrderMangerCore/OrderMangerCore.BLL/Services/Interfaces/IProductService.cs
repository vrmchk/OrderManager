using OrderManagerCore.Common.Models;

namespace OrderMangerCore.BLL.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync();
    Task<IEnumerable<ProductViewModel>> GetPageAsync(int pageNumber);
    Task<ProductViewModel> GetByIdAsync(int id);
}