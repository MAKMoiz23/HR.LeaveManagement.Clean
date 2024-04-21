namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class LeaveAllocationDTO
{
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
