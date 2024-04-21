using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
public record LeaveAllocationQuery : IRequest<IEnumerable<LeaveAllocationDTO>>;
