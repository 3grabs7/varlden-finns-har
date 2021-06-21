using Microsoft.Extensions.DependencyInjection;
using WebApp.Services;

namespace WebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISeedService, SeedService>();
            services.AddScoped<IRegistrationOfInterestService, RegistrationOfInterestService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IStaticEntitiesService, StaticEntitiesService>();
            services.AddScoped<IGeocodingService, GeocodingService>();
            services.AddScoped<IRegistrationFormService, RegistrationFormService>();

            return services;
        }
    }
}
