using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SS_EDUP.Core;
using SS_EDUP.Core.Entities;
using SS_EDUP.Infrastructure;
using SS_EDUP.Infrastructure.Context;
using SS_EDUP.Infrastructure.Initializers;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
// Database context
builder.Services.AddDbContext(connStr);

// Add Repositories
builder.Services.AddRepositories();

// Add Infrastructure Service  configurations
builder.Services.AddInfrastructureServices();

// Add Core Service  configurations
builder.Services.AddCoreServices();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add auto mapper
builder.Services.AddMapping();

// Add razor pages
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


await AppDbInitializer.SeedUsersAndRoles(app);
app.Run();
