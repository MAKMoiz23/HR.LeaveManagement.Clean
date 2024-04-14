using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HRDatabaseContext context) : base(context)
    {
    }

    //public Task<bool> LeaveTypeMustExists(int id, CancellationToken token)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<bool> ValidateUniqueName(string name, CancellationToken token)
    {
        return !await _context.Set<LeaveType>().AnyAsync(lt => lt.Name == name, token);
    }
}