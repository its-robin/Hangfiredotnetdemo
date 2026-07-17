using System.Threading.Tasks;

namespace Hangfire.AlertingDemo.Web.Services
{
    public class AlertService
    {
        /// <summary>
        /// Send an alert message (simulated).
        /// </summary>
        public Task SendAlert(string message)
        {
            Console.WriteLine($"[AlertService] Alert: {message}");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Follow-up action that can be used as a continuation job.
        /// </summary>
        public Task FollowUp(string message)
        {
            Console.WriteLine($"[AlertService] Follow-up for: {message}");
            return Task.CompletedTask;
        }
    }
}
