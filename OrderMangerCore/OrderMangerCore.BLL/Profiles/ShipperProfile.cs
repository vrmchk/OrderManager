using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.BLL.Profiles;

public class ShipperProfile : Profile
{
    public ShipperProfile()
    {
        CreateMap<Shipper, ShipperViewModel>();
    }
}