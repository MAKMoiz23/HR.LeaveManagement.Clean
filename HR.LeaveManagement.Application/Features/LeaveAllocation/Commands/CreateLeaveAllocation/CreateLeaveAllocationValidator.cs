using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    public CreateLeaveAllocationValidator(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(la => la.EmployeeId)
            .NotEmpty()
                .WithMessage("Employee id is required.");

        RuleFor(la => la.Period)
            .GreaterThan(0)
                .WithMessage("Leave allocation period must be greater than 0.")
            .LessThan(10)
                .WithMessage("Leave allocation period must be less than 10.")
            .NotNull()
                .WithMessage("Leave allocation period is required.");

        RuleFor(lt => lt)
            .MustAsync(AllocationExists)
                .WithMessage("Allocation already exists for user with same provided values.");
    }

    private async Task<bool> AllocationExists(CreateLeaveAllocationCommand command, CancellationToken cancellationToken)
    {
        return await _leaveAllocationRepository.AllocationExists(command.EmployeeId, command.LeaveTypeId, command.Period, cancellationToken);
    }
}
