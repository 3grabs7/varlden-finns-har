using Microsoft.Extensions.DependencyInjection;
using WebApp.Services;

namespace WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Interfaces implementet
            services.AddScoped<ISeedService, SeedService>();
            services.AddScoped<IRegistrationOfInterestService, RegistrationOfInterestService>();
            services.AddScoped<IScheduleService, ScheduleService>();

            // * TODO * Implement interfaces 
            services.AddScoped<StaticEntitiesService>();
            services.AddScoped<RegistrationFormService>();
            services.AddScoped<GeocodingService>();

            return services;
        }
    }
}
