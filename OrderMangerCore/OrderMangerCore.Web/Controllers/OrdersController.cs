using Microsoft.AspNetCore.Mvc;
using OrderManagerCore.Common.Models;
using OrderMangerCore.BLL.Services.Interfaces;
using OrderMangerCore.Web.Models;

namespace OrderMangerCore.Web.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private const int ordersPerPage = 10;

    public OrdersController(IOrderService orderService, IProductService productService)
    {
        _orderService = orderService;
        _productService = productService;
    }

    public IActionResult Index() => Redirect("orders/page/1");


    [HttpGet("orders/page/{page}/{searchQuery?}")]
    public async Task<IActionResult> ListOrders(int page = 1, string? searchQuery = null)
    {
        List<OrderViewModel> orders;
        int totalOrdersCount;
        if (string.IsNullOrEmpty(searchQuery))
        {
            orders = (await _orderService.GetPageAsync(page, ordersPerPage)).ToList();
            totalOrdersCount = _orderService.OrdersCount;
        }
        else
        {
            orders = (await _orderService.SearchOrdersAsync(searchQuery)).ToList();
            totalOrdersCount = orders.Count;
            orders = orders.Skip((page - 1) * ordersPerPage).Take(ordersPerPage).ToList();
        }

        var pager = new Pager(totalOrdersCount, page, ordersPerPage);
        ViewBag.SearchQuery = searchQuery!;
        ViewBag.Pager = pager;
        return View(orders);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        var products = new List<ProductViewModel>();
        foreach (var orderDetail in order.OrderDetails)
        {
            products.Add(await _productService.GetByIdAsync(orderDetail.ProductId));
        }
        ViewBag.Products = products;
        return View(order);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        var allProducts = (await _productService.GetAllAsync()).ToList();
        ViewBag.Products = allProducts;
        return View(order);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(OrderViewModel order)
    {
        await _orderService.UpdateAsync(order.Id, order);
        // return RedirectToAction(nameof(Details), new {id = order.Id});
        return Redirect($"orders/details/{order.Id}");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}