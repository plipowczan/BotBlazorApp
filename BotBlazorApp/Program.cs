using BotBlazorApp.Common.Commands;
using BotBlazorApp.Data;
using BotBlazorApp.Quartz;
using BotBlazorApp.Quartz.Jobs;
using BotBlazorApp.Services;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options => options.DetailedErrors = true);
builder.Services.AddSyncfusionBlazor(options => options.IgnoreScriptIsolation = true);
string connectionString = builder.Configuration.GetConnectionString("SqlDbContext");
builder.Services.AddDbContext<SqlDbContext>(
    options => { options.UseSqlServer(connectionString); });

builder.Services.AddSingleton<IBotChartDataService, BotChartDataService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))).AsImplementedInterfaces()
    .WithTransientLifetime());

builder.Services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>))).AsImplementedInterfaces()
    .WithTransientLifetime());

builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

builder.Services.AddServerSideBlazor(options => options.DetailedErrors = true);
builder.Services.AddSingleton<IJobFactory, QuartzJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

builder.Services.AddSingleton<AddBotChartDataJob>();
builder.Services.AddSingleton(new JobMetadata(Guid.NewGuid(), typeof(AddBotChartDataJob),
    nameof(AddBotChartDataJob), "0/30 * * ? * * *"));

builder.Services.AddControllers();
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
    builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var db = services.GetRequiredService<SqlDbContext>();
    db.Database.EnsureCreated();
    db.Database.Migrate();
}

var syncfusionLicenseKey = builder.Configuration["Syncfusion:LicenseKey"];
SyncfusionLicenseProvider.RegisterLicense(syncfusionLicenseKey);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();