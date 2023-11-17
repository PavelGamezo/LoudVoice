using LoudVoiceAPI.Common.Mapping;

namespace LoudVoiceAPI
{
    public static class Extensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddMapping();

            return services;
        }
    }
}
