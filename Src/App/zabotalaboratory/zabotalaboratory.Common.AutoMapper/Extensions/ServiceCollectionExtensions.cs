﻿using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace zabotalaboratory.Common.AutoMapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMiMapping(this IServiceCollection services, params Type[] markerTypes)
        {
            services.AddAutoMapper(markerTypes);

            return services;
        }
    }
}