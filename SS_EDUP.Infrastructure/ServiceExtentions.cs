using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Infrastructure.Context;
using SS_EDUP.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_EDUP.Infrastructure
{
    public static class ServiceExtentions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
