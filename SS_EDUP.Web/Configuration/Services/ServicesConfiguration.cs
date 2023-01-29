using Microsoft.AspNetCore.Identity;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Services;
using SS_EDUP.Infrastructure.Context;

namespace SS_EDUP.Web.Configuration.Services
{
    public class ServicesConfiguration
    {
        public static void Config(IServiceCollection services)
        {

            // Add dababase context
            services.AddDbContext<AppDbContext>();

            // Add services to the container.
            services.AddControllersWithViews();

            // Add razor pages
            services.AddRazorPages();

            // Add user service
            services.AddTransient<UserService>();

            // Add email service
            services.AddTransient<EmailService>();

            // Add Identity
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
            })
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();


        }
    }
}
