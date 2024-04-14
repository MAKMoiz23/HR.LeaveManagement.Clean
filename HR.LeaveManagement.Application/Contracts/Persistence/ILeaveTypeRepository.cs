using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> ValidateUniqueName(string name, CancellationToken token);
    //Task<bool> LeaveTypeMustExists(int id, CancellationToken token);
}
