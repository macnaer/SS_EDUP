using SS_EDUP.Core.Interfaces;
using SS_EDUP.Core.Services;
using SS_EDUP.Infrastructure.Repository;

namespace SS_EDUP.Web.Configuration.Repositories
{
    public class RepositoriesConfiguration
    {
        public static void Config(IServiceCollection services)
        {
            // Add generic repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // service configurations
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}
