using Microsoft.EntityFrameworkCore;
using TestApp2.Interfaces;

namespace TestApp2.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMainContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<MainContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IMainDbContext>(serviceProvider =>
            {
                var context = serviceProvider.GetService<MainContext>();
                try
                {
                    context.Database.EnsureCreated();
                }
                catch { }
                return context;
            });

            return services;
        }
    }
}