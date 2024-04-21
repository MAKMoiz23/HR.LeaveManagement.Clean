using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetById(request.Id, cancellationToken);
        // verify if exists to Do

        await _leaveAllocationRepository.Delete(leaveAllocation, cancellationToken);

        return Unit.Value;
    }
}
