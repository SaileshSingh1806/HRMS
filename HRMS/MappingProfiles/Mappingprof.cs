using AutoMapper;
using HRMS.Authentication;
using HRMS.DTO;
using HRMS.Models;
using Microsoft.AspNetCore.Identity;

namespace HRMS.MappingProfiles
{
    public class Mappingprof : Profile
    {
        public Mappingprof()
        {
            CreateMap<Employee, EmpDTO>().ReverseMap();

            CreateMap<Leave, LeaveDTO>().ReverseMap();

            CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();   

        }
    }
}
