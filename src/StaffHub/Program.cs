﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Contexts;
using Persistence.Repositories;
using Services;
using Services.Interfaces;
using Services.Interfaces.Repositories;
using StaffHub.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(ApplicationDbContextFactory.CONNECTION_STRING));

builder.Services.AddScoped<CalendarFetchService>(provider =>
{
    var dbContext = provider.GetRequiredService<ApplicationDbContext>();
    return new CalendarFetchService(dbContext);
});



builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.AddScoped<ICustomEmailSender, CustomEmailSender>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
