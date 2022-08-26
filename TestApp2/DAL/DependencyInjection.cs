using Microsoft.EntityFrameworkCore;
using TestApp2.DAL;

namespace TestApp2.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("cs");

            services.AddDbContext<MainContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<MainContext>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<MainContext>();
                try
                {
                    DbInitializer.Initialize(context);
                }
                catch { }
                return context;
            });

            return services;
        }
    }
}
