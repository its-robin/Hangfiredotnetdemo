using Hangfire;
using Hangfire.SqlServer;
using Hangfire.AlertingDemo.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// load optional appsettings.json (contains connection string for LocalDB)
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\mssqllocaldb;Database=HangfireAlertingDemo;Trusted_Connection=True;";

builder.Services.AddHangfire(config => config
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.FromSeconds(15),
        UseRecommendedIsolationLevel = true,
        EnableHeavyMigrations = true
    }));

builder.Services.AddHangfireServer();

// application services (job handlers)
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<ReportService>();
builder.Services.AddSingleton<AlertService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Hangfire dashboard exposes job monitoring UI at /hangfire
app.UseHangfireDashboard("/hangfire");

app.MapControllers();

// create a demo recurring job on startup (runs daily by default)
RecurringJob.AddOrUpdate<ReportService>("daily-report", s => s.GenerateAsync(), Cron.Daily);

app.Run();
