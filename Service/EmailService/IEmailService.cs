
using ms_partnership.Models.Entities;

namespace ms_partnership.Service.EmailService
{
    public interface IEmailService
    {
        void sendMail(Email request);
    }
}