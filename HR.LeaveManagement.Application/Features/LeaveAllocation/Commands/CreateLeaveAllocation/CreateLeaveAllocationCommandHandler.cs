using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        //Validation
        var validator = new CreateLeaveAllocationValidator(_leaveAllocationRepository);

        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            //implement logging or required steps
            Console.WriteLine("Invalid");
        }

        //Conversion from Command
        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        //Add to database
        await _leaveAllocationRepository.Create(leaveAllocation, cancellationToken);

        return leaveAllocation.Id;
    }
}
