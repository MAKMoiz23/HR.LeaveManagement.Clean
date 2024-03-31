using HR.LeaveManagement.Application.Models.Email;

namespace HR.LeaveManagement.Application.Contracts.Email;

public interface IEmaiSender
{
    Task<bool> SendEmail(EmailMessage email ,CancellationToken cancellationToken);
}
