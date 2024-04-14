using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logger;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    //private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;
    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper 
        //,IAppLogger<CreateLeaveTypeCommandHandler> logger
        )
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        //_logger = logger;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //Validations
        var validator = new CreateleaveTypeCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            //_logger.LogWarning("Validation failed for {0}", nameof(LeaveType));
            // need to implement custom exception
            Console.WriteLine("Invalid");

        //Conversions
        var leaveTypeToAdd = _mapper.Map<Domain.LeaveType>(request);

        //Create in DB
        await _leaveTypeRepository.Create(leaveTypeToAdd, cancellationToken);

        //_logger.LogInformation("{0} - {1} created successfully.", nameof(LeaveType), leaveTypeToAdd.Id);

        //return
        return leaveTypeToAdd.Id;
    }
}
