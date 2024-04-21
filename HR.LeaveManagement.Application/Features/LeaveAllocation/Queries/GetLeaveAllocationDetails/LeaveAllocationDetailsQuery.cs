using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
public record LeaveAllocationDetailsQuery(int Id) : IRequest<LeaveAllocationDetailsDTO>;
