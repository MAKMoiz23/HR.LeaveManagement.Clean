using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HRDatabaseContext context) : base(context)
    {
    }

    public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsWithDetails(CancellationToken cancellationToken)
    {
        return await _context.Set<LeaveRequest>()
            .Include(lr => lr.LeaveType)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsWithDetails(string userId, CancellationToken cancellationToken)
    {
        return await _context.Set<LeaveRequest>()
            .Where(lr => lr.RequestingEmployeeId == userId)
            .Include(lr => lr.LeaveType)
            .ToListAsync(cancellationToken);
    }

    public Task<LeaveRequest?> GetLeaveRequestWithDetails(int id, CancellationToken cancellationToken)
    {
        return _context.Set<LeaveRequest>().Where(lr => lr.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}
