﻿using Microsoft.Extensions.DependencyInjection;

namespace LoudVoice.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}