# Hangfire Alerting Demo

This repository is a demo project to explore Hangfire features on .NET 8. It showcases:

- Fire-and-forget jobs
- Delayed jobs
- Recurring jobs
- Job continuations
- Dashboard monitoring (Hangfire Dashboard)
- LocalDB (SQL Server) persistence using Hangfire.SqlServer
- Simple REST API and a lightweight web UI for triggering jobs

## Quick start

Prerequisites:
- .NET 8 SDK
- (Optional) LocalDB / SQL Server Express (LocalDB is used by default)

Run locally:
1. Restore and build in Visual Studio or via CLI:

   dotnet build

2. Run the web app:

   dotnet run --project Hangfire.AlertingDemo.Web

3. Open UI at: http://localhost:5000 (or the port shown in your console)
4. Open Hangfire dashboard at: http://localhost:5000/hangfire

## Project layout

- Program.cs - App startup, Hangfire configuration and dashboard
- Controllers/JobsController.cs - API to enqueue/schedule jobs
- Services/* - Example job handlers (EmailService, ReportService, AlertService)
- wwwroot/index.html - Simple UI for demonstration

## Notes

- The demo uses LocalDB by default. Change the connection string in `appsettings.json` to point to a full SQL Server if desired.
- Recurring job `demo-report` is set to run every minute for demo purposes when you invoke the recurring endpoint.

## Next steps / polish ideas

- Integrate a real email provider (SMTP/SendGrid)
- Add authentication around the Hangfire dashboard
- Add unit/integration tests for job logic

---

Built as a learning demo. Feel free to fork and extend.
