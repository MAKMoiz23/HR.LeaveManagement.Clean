using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
public class LeaveAllocationDetailsQueryHandler : IRequestHandler<LeaveAllocationDetailsQuery, LeaveAllocationDetailsDTO>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public LeaveAllocationDetailsQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<LeaveAllocationDetailsDTO> Handle(LeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(request.Id, cancellationToken);

        var data = _mapper.Map<LeaveAllocationDetailsDTO>(leaveAllocation);

        return data;
    }
}
