using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validations

        //conversions
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

        //Update in DB
        await _leaveTypeRepository.Update(leaveTypeToUpdate, cancellationToken);

        //return
        return Unit.Value;
    }
}
