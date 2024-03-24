using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateleaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateleaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
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

    private Task<bool> UniqueNameCheck(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return _leaveTypeRepository.ValidateUniqueName(command.Name, token);
    }
}
