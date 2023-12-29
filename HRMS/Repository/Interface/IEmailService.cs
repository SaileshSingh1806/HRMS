using HRMS.Models.Email;

namespace HRMS.Repository.Interface
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage message);
    }
}
