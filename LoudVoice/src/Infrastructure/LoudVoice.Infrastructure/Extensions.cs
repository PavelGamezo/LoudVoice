using LoudVoice.Application.Common.Authentications;
using LoudVoice.Application.Common.Persistance;
using LoudVoice.Application.Common.Services;
using LoudVoice.Infrastructure.Authentications;
using LoudVoice.Infrastructure.EF.Contexts;
using LoudVoice.Infrastructure.EF.Repositories;
using LoudVoice.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoudVoice.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionString)
        {
            services.AddDbContext<LoudVoiceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}