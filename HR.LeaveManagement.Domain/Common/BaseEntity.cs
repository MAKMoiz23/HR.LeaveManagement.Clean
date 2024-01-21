namespace HR.LeaveManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? ModifiedOn { get; set; }
}
