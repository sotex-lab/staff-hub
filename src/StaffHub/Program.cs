using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.IRepository;
using Persistence.Repositories;
using Services;
using StaffHub.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(ApplicationDbContextFactory.CONNECTION_STRING));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Logging.AddSimpleConsole(x =>
{
    x.SingleLine = true;
    x.TimestampFormat = "HH:mm:ss ";
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomEmailSender, CustomEmailSender>();
builder.Services.AddTransient<ICalendarFetchService, CalendarFetchService>();
builder.Services.AddHostedService<CalendarSyncher>();

var app = builder.Build();

var dbContext = new ApplicationDbContextFactory().CreateDbContext(new string[] { });
dbContext.Database.Migrate();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapRazorPages();

app.Run();
