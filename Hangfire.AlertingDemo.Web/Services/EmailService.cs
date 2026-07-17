using System.Threading.Tasks;

namespace Hangfire.AlertingDemo.Web.Services
{
    public class EmailService
    {
        /// <summary>
        /// Simulate sending an email. Replace with real provider in production.
        /// </summary>
        /// <param name="to">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="body">Email body</param>
        public Task SendEmail(string to, string subject, string body)
        {
            // Simulate email send - in a real app integrate with SMTP or SendGrid
            Console.WriteLine($"[EmailService] Sending email to {to} - {subject}\n{body}");
            return Task.CompletedTask;
        }
    }
}
