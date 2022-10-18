using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.BLL.Services.Interfaces;
using OrderMangerCore.DAL.Entities;
using OrderMangerCore.DAL.Repositories.Interfaces;

namespace OrderMangerCore.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepo _orderRepo;
    private readonly IProductRepo _productRepo;

    public OrderService(IOrderRepo orderRepo, IMapper mapper, IProductRepo productRepo)
    {
        _orderRepo = orderRepo;
        _mapper = mapper;
        _productRepo = productRepo;
        OrdersCount = _orderRepo.Table.Count();
    }

    public int OrdersCount { get; }

    public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
    {
        var orders = await _orderRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
    }

    public async Task<OrderViewModel> GetByIdAsync(int id)
    {
        var order = await _orderRepo.FindAsync(id);
        return _mapper.Map<OrderViewModel>(order);
    }

    public async Task<IEnumerable<OrderViewModel>> GetPageAsync(int page, int ordersPerPage)
    {
        if (page < 1)
            page = 1;
        var orders =
            await _orderRepo.GetItemsAfter(ordersPerPage * (page - 1) + _orderRepo.FirstId, ordersPerPage);
        return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
    }

    public async Task<IEnumerable<OrderViewModel>> SearchOrdersAsync(string query)
    {
        var orders = (await _orderRepo.FindByProperty(query))
            .Union(await _orderRepo.FindByCustomer(query))
            .Union(await _orderRepo.FindByEmployee(query))
            .Union(await _orderRepo.FindByShipper(query));

        return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
    }

    public async Task<OrderViewModel> UpdateAsync(int id, OrderViewModel orderViewModel)
    {
        if (id != orderViewModel.Id)
            throw new Exception(nameof(id));

        var order = await _orderRepo.FindAsync(id);
        if (order == null)
            throw new Exception(nameof(order));

        foreach (var orderDetailViewModel in orderViewModel.OrderDetails)
        {
            var product = await _productRepo.FindAsync(orderDetailViewModel.ProductId);
            if (product == null)
                throw new Exception(nameof(product));
        }

        _mapper.Map(orderViewModel, order);
        return _mapper.Map<OrderViewModel>(order);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepo.FindAsync(id);
        if (order == null)
            throw new Exception(nameof(order));

        await _orderRepo.DeleteAsync(order);
    }

    public async Task<IEnumerable<OrderViewModel>> GetSearchPageAsync(string query, int page, int ordersPerPage)
    {
        return (await SearchOrdersAsync(query)).Skip((page - 1) * ordersPerPage).Take(ordersPerPage);
    }
}