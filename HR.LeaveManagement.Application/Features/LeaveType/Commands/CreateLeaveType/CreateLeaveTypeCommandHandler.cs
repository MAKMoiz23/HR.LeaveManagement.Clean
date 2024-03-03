using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validations
        var validator = new CreateleaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
            // need to implement custom exception
            Console.WriteLine("Invalid");

        //Conversions
        var leaveTypeToAdd = _mapper.Map<Domain.LeaveType>(request);

        //Create in DB
        await _leaveTypeRepository.Create(leaveTypeToAdd, cancellationToken);

        //return
        return leaveTypeToAdd.Id;
    }
}
