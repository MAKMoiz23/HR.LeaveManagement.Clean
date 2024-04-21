
namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class LeaveAllocationDetailsDTO
{
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
