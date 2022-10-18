using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.BLL.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryViewModel>();
    }
}