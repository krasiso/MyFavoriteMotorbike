﻿using MyFavoriteMotorbike.Core.Contracts;
using MyFavoriteMotorbike.Core.Exceptions;
using MyFavoriteMotorbike.Core.Services;
using MyFavoriteMotorbike.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyFavoriteMotorbikeServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMotorbikeService, MotorbikeService>();
            services.AddScoped<IGoldenClientService, GoldenClientService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }
    }
}
