using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            // Add user service
            services.AddTransient<UserService>();

            // Add email service
            services.AddTransient<EmailService>();

            // Add Course service
            services.AddTransient<CoursesService>();

            // Add Category service
            services.AddTransient<CategoriesService>();

        }
    }
}
