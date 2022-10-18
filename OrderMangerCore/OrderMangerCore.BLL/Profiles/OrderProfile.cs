using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.BLL.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config => config.AddProfiles(new Profile[]
            {new OrderDetailProfile(), new CustomerProfile(), new EmployeeProfile(), new ShipperProfile()})));

        CreateMap<Order, OrderViewModel>()
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => mapper.Map<ICollection<OrderDetailViewModel>>(src.OrderDetails)))
            .ForMember(dest => dest.Shipper,
                opt => opt.MapFrom(src => mapper.Map<ShipperViewModel>(src.ShipperNavigation)))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => mapper.Map<CustomerViewModel>(src.Customer)))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => mapper.Map<EmployeeViewModel>(src.Employee)));

        CreateMap<OrderViewModel, Order>()
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => mapper.Map<List<OrderDetail>>(src.OrderDetails)));
    }
}