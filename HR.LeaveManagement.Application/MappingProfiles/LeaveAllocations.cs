using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;
public class LeaveAllocations : Profile
{
    public LeaveAllocations()
    {
        CreateMap<LeaveAllocation, LeaveAllocationDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LeaveType!.Name))
            .ForMember(dest => dest.DefaultDays, opt => opt.MapFrom(src => src.LeaveType!.DefaultDays))
            .ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDetailsDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LeaveType!.Name))
            .ForMember(dest => dest.DefaultDays, opt => opt.MapFrom(src => src.LeaveType!.DefaultDays));
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
    }
}
