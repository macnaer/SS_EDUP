using Microsoft.EntityFrameworkCore;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Core.Services;
using SS_EDUP.Infrastructure.Context;
using SS_EDUP.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
string connStr = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connStr));

// Add generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add user service
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
