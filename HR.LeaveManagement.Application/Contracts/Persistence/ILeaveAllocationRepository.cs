using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationsWithDetails(CancellationToken cancellationToken);
    Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId ,CancellationToken cancellationToken);
    Task<LeaveAllocation?> GetLeaveAllocationsWithDetails(int id, CancellationToken cancellationToken);
    Task<bool> AllocationExists(string userId, int leaveTypeId, int period, CancellationToken cancellationToken);
    Task AddAllocations(IEnumerable<LeaveAllocation> allocations, CancellationToken cancellationToken);
    Task<IEnumerable<LeaveAllocation>> GetUserAllocations(int leaveTypeid, string userId, CancellationToken cancellationToken);
}
