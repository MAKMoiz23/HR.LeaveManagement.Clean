
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class LeaveAllocationQueryHandler : IRequestHandler<LeaveAllocationQuery, IEnumerable<LeaveAllocationDTO>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public LeaveAllocationQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LeaveAllocationDTO>> Handle(LeaveAllocationQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(cancellationToken);

        var data = _mapper.Map<IEnumerable<LeaveAllocationDTO>>(leaveAllocations);

        return data;
    }
}
