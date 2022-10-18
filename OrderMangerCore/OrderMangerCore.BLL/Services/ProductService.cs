using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.BLL.Services.Interfaces;
using OrderMangerCore.DAL.Repositories.Interfaces;

namespace OrderMangerCore.BLL.Services;

public class ProductService : IProductService
{
    private readonly IProductRepo _productRepo;
    private readonly IMapper _mapper;


    public ProductService(IProductRepo productRepo, IMapper mapper)
    {
        _productRepo = productRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        var products = await _productRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductViewModel>>(products);
    }

    public Task<IEnumerable<ProductViewModel>> GetPageAsync(int pageNumber)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductViewModel> GetByIdAsync(int id)
    {
        var product = await _productRepo.FindAsync(id);
        return _mapper.Map<ProductViewModel>(product);
    }
}