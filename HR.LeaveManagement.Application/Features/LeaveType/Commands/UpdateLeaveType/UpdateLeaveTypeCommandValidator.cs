using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(lt => lt.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExists);
        RuleFor(lt => lt.Name)
            .NotEmpty()
                .WithMessage($"Property name Cannot be empty.")
            .NotNull()
                .WithMessage($"Property name cannot be null.")
            .MaximumLength(50)
                .WithMessage("Property name cannot have more than 50 characters.");

        RuleFor(lt => lt.DefaultDays)
            .LessThanOrEqualTo(20)
                .WithMessage($"Property default days cannot exceed 20.")
            .GreaterThanOrEqualTo(1)
                .WithMessage($"Property default days cannot be smaller than 1.");

        RuleFor(lt => lt)
            .MustAsync(UniqueNameCheck)
                .WithMessage($"Name already exists.");
        _leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeMustExists(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetById(id, token);
        return leaveType != null;
    }

    private Task<bool> UniqueNameCheck(UpdateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.ValidateUniqueName(command.Name, token);
    }
}
