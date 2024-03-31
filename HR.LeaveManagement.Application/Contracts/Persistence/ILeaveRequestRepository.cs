using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest?> GetLeaveRequestWithDetails(int id, CancellationToken cancellationToken);
    Task<IEnumerable<LeaveRequest>> GetLeaveRequestsWithDetails(CancellationToken cancellationToken);
    Task<IEnumerable<LeaveRequest>> GetLeaveRequestsWithDetails(string userId, CancellationToken cancellationToken);
}