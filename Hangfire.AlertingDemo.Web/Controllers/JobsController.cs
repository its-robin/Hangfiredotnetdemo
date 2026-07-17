using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;
using Hangfire.AlertingDemo.Web.Models;
using Hangfire.AlertingDemo.Web.Services;

namespace Hangfire.AlertingDemo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IBackgroundJobClient _jobs;
        private readonly JobStorage _storage;

        public JobsController(IBackgroundJobClient jobs)
        {
            _jobs = jobs;
            _storage = JobStorage.Current;
        }

        [HttpPost("fire-and-forget")]
        public IActionResult FireAndForget([FromBody] JobRequest request)
        {
            /// Enqueue a fire-and-forget job that sends an email.
            var id = _jobs.Enqueue<EmailService>(s => s.SendEmail(request.To ?? "test@example.com", request.Subject ?? "Hello", request.Body ?? "Body"));
            return Ok(new { jobId = id });
        }

        [HttpPost("delayed")]
        public IActionResult Delayed([FromBody] JobRequest request)
        {
            var delay = TimeSpan.FromSeconds(request.DelaySeconds > 0 ? request.DelaySeconds : 30);
            var id = _jobs.Schedule<EmailService>(s => s.SendEmail(request.To ?? "test@example.com", request.Subject ?? "Delayed", request.Body ?? "Delayed body"), delay);
            return Ok(new { jobId = id, scheduledInSeconds = delay.TotalSeconds });
        }

        [HttpPost("continuation")]
        public IActionResult Continuation([FromBody] JobRequest request)
        {
            // create a parent job and schedule a continuation that runs after parent completes
            var parentId = _jobs.Enqueue<AlertService>(s => s.SendAlert(request.Message ?? "Initial alert"));
            var contId = BackgroundJob.ContinueJobWith<AlertService>(parentId, s => s.FollowUp(request.Message ?? "Initial alert"));
            return Ok(new { parentId, continuationId = contId });
        }

        [HttpPost("recurring")]
        public IActionResult Recurring()
        {
            RecurringJob.AddOrUpdate<ReportService>("demo-report", s => s.GenerateAsync(), Cron.Minutely);
            return Ok(new { recurringId = "demo-report", schedule = "Every minute (for demo)" });
        }

        [HttpGet("monitoring")]
        public IActionResult Monitoring()
        {
            var monitor = _storage.GetMonitoringApi();
            var stats = monitor.GetStatistics();
            return Ok(new
            {
                stats.Enqueued,
                stats.Processing,
                stats.Scheduled,
                stats.Failed,
                stats.Succeeded,
                stats.Recurring
            });
        }
    }
}
