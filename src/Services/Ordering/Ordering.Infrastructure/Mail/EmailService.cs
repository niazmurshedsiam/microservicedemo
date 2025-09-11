using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Models;
using QuickMailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(EmailMessage emailMessage)
        {
            Email email = new Email();

            if (email.IsValidEmail(emailMessage.To))
            {
                return email.SendEmail(emailMessage.To,EmailCredential.EmailAddress,EmailCredential.Password,emailMessage.Subject,emailMessage.Body);
            }
            return false;
        }
    }
}
