using System.Threading.Tasks;

namespace Hangfire.AlertingDemo.Web.Services
{
    public class ReportService
    {
        /// <summary>
        /// Generate a demo report. Intended to be used as a recurring job.
        /// </summary>
        public Task GenerateAsync()
        {
            Console.WriteLine($"[ReportService] Generating report at {DateTime.UtcNow}");
            return Task.CompletedTask;
        }
    }
}
