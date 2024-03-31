using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HRDatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(IEnumerable<LeaveAllocation> allocations, CancellationToken cancellationToken)
    {
        await _context.Set<LeaveAllocation>()
            .AddRangeAsync(allocations, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> AllocationExists(string userId, int leaveTypeId, int period, CancellationToken cancellationToken)
    {
        return _context.Set<LeaveAllocation>()
            .AnyAsync(la => la.LeaveTypeId == leaveTypeId && la.NumberOfDays == period && la.EmployeeId == userId, cancellationToken);
    }

    public async Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationsWithDetails(CancellationToken cancellationToken)
    {
        return await _context.Set<LeaveAllocation>()
            .Include(la => la.LeaveType)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<IEnumerable<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId, CancellationToken cancellationToken)
    {
        return await _context.Set<LeaveAllocation>()
            .Include(la => la.LeaveType)
            .ToListAsync(cancellationToken);
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationsWithDetails(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<LeaveAllocation>()
            .Where(la => la.Id == id)
            .Include(la => la.LeaveType)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<LeaveAllocation>> GetUserAllocations(int leaveTypeid, string userId, CancellationToken cancellationToken)
    {
        return await _context.Set<LeaveAllocation>()
            .Where(la => la.LeaveTypeId == leaveTypeid && la.EmployeeId == userId)
            .ToListAsync(cancellationToken);
    }
}
