using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.BLL.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerViewModel>();
    }
}