using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.BLL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config => config.AddProfiles(
            new Profile[] {new CategoryProfile()})));

        CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => mapper.Map<CategoryViewModel>(src.Category)));
    }
}