using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Retrieve from DB
        var leaveTypeToDelete = await _leaveTypeRepository.GetById(request.Id, cancellationToken);
        //Verify that entity exists...To Do
        //Delete from DB
        await _leaveTypeRepository.Delete(leaveTypeToDelete, cancellationToken);

        //return
        return Unit.Value;
    }
}
