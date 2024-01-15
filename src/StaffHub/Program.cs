using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contexts;
using Services;
using StaffHub.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(ApplicationDbContextFactory.CONNECTION_STRING));

builder.Services.AddRazorPages();


builder.Services.AddScoped<CalendarFetchService>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDbContext>();
    return new CalendarFetchService(dbContext);
});



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

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
