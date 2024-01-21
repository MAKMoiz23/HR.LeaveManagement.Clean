using HR.LeaveManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequsted { get; set; }
    public string? RequestComments { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public required string RequestingEmployeeId { get; set; }

    [ForeignKey(nameof(LeaveTypeId))]
    public LeaveType? LeaveType { get; set; }
}