using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        //validations
        var validator = new UpdateLeaveAllocationValidator(_leaveAllocationRepository);

        var validationResults = await validator.ValidateAsync(request);

        if (!validationResults.IsValid) 
        {
            //do some thing custome ex etc...
            Console.WriteLine("Invalid");
        }

        //conversions from dto
        var data = _mapper.Map<Domain.LeaveAllocation>(request);
        //update in db
        await _leaveAllocationRepository.Update(data, cancellationToken);

        return Unit.Value;
    }
}
