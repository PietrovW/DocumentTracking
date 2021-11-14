using DocumentTracking.Infrastructure.AutoMapper;
using DocumentTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace DocumentTracking.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            //Register DbContext
            services.AddDbContext<DocumentTrackingContext>(options);

            //Register AutoMapper 
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            //Register Application Services
           // services.AddTransient<ITermsService, TermsService>();

            return services;
        }
    }
}
