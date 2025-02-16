﻿using zabotalaboratory.Analyses.Database.Extensions;
using zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses;
using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Analyses.Database.Repository.Analyses;
using zabotalaboratory.Analyses.Database.Repository.Clinics;

namespace zabotalaboratory.Analyses.Database.Repository.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAnalysesRepository(this IServiceCollection services, string connectionString)
        {
            services.AddAnalysesDatabase(connectionString);
            services.AddScoped<ILaboratoryAnalysesRepository, LaboratoryAnalysesRepository>();
            services.AddScoped<IAnalysesRepository, AnalysesRepository>();
            services.AddScoped<IClinicsRepository, ClinicsRepository>();
            return services;
        }
    }
}
