using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class LeaveTypesQueryHandler : IRequestHandler<LeaveTypesQuery, IEnumerable<LeaveTypeDTO>>
{

    private readonly IMapper _mapper;
    public readonly ILeaveTypeRepository _leaveRepo;
    public LeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveRepo)
    {
        _mapper = mapper;
        _leaveRepo = leaveRepo;
    }

    public async Task<IEnumerable<LeaveTypeDTO>> Handle(LeaveTypesQuery request, CancellationToken cancellationToken)
    {
        //Query Database
        var leaveTypes = await _leaveRepo.GetAll(cancellationToken);

        //Map To DTO
        var data = _mapper.Map<IEnumerable<LeaveTypeDTO>>(leaveTypes);

        //return records
        return data;
    }
}
