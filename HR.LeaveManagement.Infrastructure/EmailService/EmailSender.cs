using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService;
public class EmailSender : IEmaiSender
{
    public readonly EmailSettings _emailSettings;
    public EmailSender(IOptions<EmailSettings> options)
    {
        _emailSettings = options.Value;
    }
    public async Task<bool> SendEmail(EmailMessage email, CancellationToken cancellationToken)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress { Email = _emailSettings.FromAddress, Name = _emailSettings.FromName };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

        var response = await client.SendEmailAsync(message, cancellationToken);

        return response.IsSuccessStatusCode;
    }
}
