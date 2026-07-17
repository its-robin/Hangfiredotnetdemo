# Hangfire Alerting Demo

> A complete **.NET 8** demonstration of [Hangfire](https://www.hangfire.io/) job scheduling and processing, featuring fire-and-forget jobs, recurring jobs, delayed executions, and a monitoring dashboard.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)

## 🎯 Overview

A practical, production-ready example of Hangfire job scheduling on .NET 8 with SQL Server persistence. Perfect for learning Hangfire, building job processing systems, or using as a starter template for your background job needs.

## ✨ Features

- ✅ **Fire-and-forget jobs** - Execute jobs immediately
- ✅ **Delayed jobs** - Schedule jobs for future execution
- ✅ **Recurring jobs** - Run jobs on a schedule (cron expressions)
- ✅ **Job continuations** - Chain jobs together
- ✅ **Dashboard monitoring** - Real-time job status and history via Hangfire Dashboard
- ✅ **SQL Server persistence** - LocalDB or full SQL Server support
- ✅ **REST API** - Trigger and manage jobs via HTTP endpoints
- ✅ **Web UI** - Simple, lightweight interface for triggering demo jobs

## 🚀 Quick Start

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Either:
  - **LocalDB** (included with Visual Studio) - default option
  - **SQL Server Express** - lightweight alternative
  - **SQL Server** - full production database

### Installation & Running

```bash
# Clone the repository
git clone https://github.com/its-robin/Hangfiredotnetdemo.git
cd Hangfiredotnetdemo

# Restore dependencies and build
dotnet build

# Run the application
dotnet run --project Hangfire.AlertingDemo.Web
```

### Access the Application

- **Web UI**: http://localhost:5000
- **Hangfire Dashboard**: http://localhost:5000/hangfire
- **API Endpoints**: See below

## 📋 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/jobs/fire-and-forget` | Enqueue a job to run immediately |
| `POST` | `/api/jobs/delayed` | Schedule a job to run after a delay |
| `POST` | `/api/jobs/recurring` | Set up a recurring job |
| `GET` | `/api/jobs/status/{jobId}` | Check job status |

## 📁 Project Structure

```
Hangfire.AlertingDemo.Web/
├── Controllers/
│   └── JobsController.cs          # API endpoints for job management
├── Services/
│   ├── AlertService.cs            # Alert job handler
│   ├── EmailService.cs            # Email job handler
│   └── ReportService.cs           # Report generation handler
├── Models/
│   └── JobRequest.cs              # Request DTOs
├── Program.cs                     # Hangfire setup & configuration
├── appsettings.json              # Connection string & settings
└── wwwroot/
    ├── index.html                # Web UI
    └── js/jobs.js                # UI JavaScript
```

## ⚙️ Configuration

### Connection String

By default, the app uses **LocalDB**. To use a different database, edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HangfireAlertingDemo;Trusted_Connection=True;"
  }
}
```

**For SQL Server Express:**
```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=HangfireAlertingDemo;Trusted_Connection=True;"
```

**For Azure SQL Database:**
```json
"DefaultConnection": "Server=tcp:yourserver.database.windows.net,1433;Initial Catalog=HangfireAlertingDemo;Persist Security Info=False;User ID=admin;Password=YourPassword;Encrypt=True;Connection Timeout=30;"
```

## 🎓 Learning & Examples

### Fire-and-forget Job
```csharp
BackgroundJob.Enqueue(() => emailService.SendAlert("user@example.com", "Alert!"));
```

### Delayed Job
```csharp
BackgroundJob.Schedule(() => reportService.GenerateReport(), TimeSpan.FromMinutes(5));
```

### Recurring Job
```csharp
RecurringJob.AddOrUpdate("my-report", () => reportService.GenerateReport(), Cron.Daily);
```

## 🛠️ Extending the Demo

### Add a New Job Handler

1. Create a service in `Services/` folder:
```csharp
public class MyCustomService
{
    public void DoSomething() => Console.WriteLine("Job executed!");
}
```

2. Register in `Program.cs`:
```csharp
builder.Services.AddScoped<MyCustomService>();
```

3. Use in your controller:
```csharp
BackgroundJob.Enqueue<MyCustomService>(x => x.DoSomething());
```

### Secure the Dashboard

Add authentication middleware before registering Hangfire Dashboard:
```csharp
app.UseHangfireDashboard("/hangfire", new DashboardOptions 
{ 
    Authorization = new[] { new BasicAuthAuthorizationFilter(...) }
});
```

## 📚 Dependencies

- [Hangfire](https://www.hangfire.io/) - Background job processing
- [Hangfire.SqlServer](https://www.nuget.org/packages/Hangfire.SqlServer) - SQL Server storage
- [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) - Database connectivity
- ASP.NET Core 8.0 - Web framework

## 🤝 Contributing

Contributions are welcome! To contribute:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/awesome-feature`)
3. **Commit** your changes (`git commit -m 'Add awesome feature'`)
4. **Push** to the branch (`git push origin feature/awesome-feature`)
5. **Open** a Pull Request

Please ensure:
- Code follows C# conventions
- Changes are well-documented
- Existing tests still pass (see [Testing](#-testing) section)

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test Hangfire.AlertingDemo.Tests
```

## 📝 License

This project is licensed under the **MIT License** - see the [LICENSE](../LICENSE) file for details.

## 🔗 Resources & Links

- [Hangfire Official Documentation](https://docs.hangfire.io/)
- [.NET 8 Release Notes](https://github.com/dotnet/core/releases/tag/v8.0.0)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Background Jobs Best Practices](https://docs.hangfire.io/en/latest/background-methods/index.html)

## ⚡ Roadmap / Next Steps

- [ ] Add integration tests
- [ ] Implement authentication for Dashboard
- [ ] Add real email provider integration (SendGrid/SMTP)
- [ ] Docker support (Dockerfile & docker-compose.yml)
- [ ] Add logging with Serilog
- [ ] Advanced error handling and retry policies
- [ ] Performance monitoring and metrics
- [ ] Database migrations with EF Core

## 💬 Support & Questions

- Open an [Issue](https://github.com/its-robin/Hangfiredotnetdemo/issues) for bugs or feature suggestions
- Start a [Discussion](https://github.com/its-robin/Hangfiredotnetdemo/discussions) for questions
- Check [existing discussions](https://github.com/its-robin/Hangfiredotnetdemo/discussions) for common answers

## 🌟 Show Your Support

If you find this project helpful, please consider:
- ⭐ Starring the repository
- 🔀 Forking and extending it
- 📢 Sharing it with the community
- 💬 Leaving feedback or suggestions

---

Built as a learning demo. Feel free to fork and extend.
