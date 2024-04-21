using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
public record UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
    public int LeaveTypeId { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}
