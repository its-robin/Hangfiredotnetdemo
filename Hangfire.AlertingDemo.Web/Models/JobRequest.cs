namespace Hangfire.AlertingDemo.Web.Models
{
    public class JobRequest
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int DelaySeconds { get; set; }
        public string? Message { get; set; }
    }
}
