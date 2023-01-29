using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Core.Services;
using SS_EDUP.Infrastructure.Context;
using SS_EDUP.Infrastructure.Repository;
using SS_EDUP.Web.Configuration.AutoMapper;
using SS_EDUP.Web.Configuration.Repositories;
using SS_EDUP.Web.Configuration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add AutoMapper configuration 
AutoMapperConfiguration.Config(builder.Services);

//Add Services configuration
ServicesConfiguration.Config(builder.Services);

// Add Repositories configuration
RepositoriesConfiguration.Config(builder.Services);


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

app.Run();
