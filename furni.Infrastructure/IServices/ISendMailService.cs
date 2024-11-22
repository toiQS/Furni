using furni.Infrastructure.Helpers;

namespace furni.Infrastructure.IServices
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}
