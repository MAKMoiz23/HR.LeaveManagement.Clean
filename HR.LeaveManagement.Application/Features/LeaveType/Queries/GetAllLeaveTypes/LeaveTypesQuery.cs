using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record LeaveTypesQuery : IRequest<IEnumerable<LeaveTypeDTO>>;
