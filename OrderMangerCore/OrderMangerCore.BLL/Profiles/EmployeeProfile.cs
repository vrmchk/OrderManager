using AutoMapper;
using OrderManagerCore.Common.Models;
using OrderMangerCore.DAL.Entities;

namespace OrderMangerCore.BLL.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeViewModel>();
    }
}