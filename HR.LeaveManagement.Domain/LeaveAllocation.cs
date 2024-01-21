using HR.LeaveManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation : BaseEntity
{
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
    public int LeaveTypeId { get; set; }

    [ForeignKey(nameof(LeaveTypeId))]
    public LeaveType? LeaveType { get; set; }
}
