using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DocumentTracking.Infrastructure.Filter;
using DocumentTracking.Infrastructure.Services;
using DocumentTracking.Infrastructure.Options;
using MediatR;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using DocumentTracking.Api.Extensions;
using DocumentTracking.Infrastructure.Services.Intecace;

namespace DocumentTracking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.Configure<DataProtectionTokenProviderOptions>(x => x.TokenLifespan = TimeSpan.FromDays(15));
            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly);
            services.AddConfigureDatabases(Configuration);
            services.AddConfigureIdentity();
            services.Configure<EmailOptions>("emailOptions", Configuration);
            services.AddOptions();
            services.AddTokenAuthentication(Configuration);
            services.AddHttpContextAccessor();
            services.AddAppSwaggerGen();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IOCRService, OCRService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJWTTokenHandler, JWTTokenHandler>();
            services.AddMediatR(typeof(IdentityService).GetTypeInfo().Assembly);
        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
           // builder.AddMediatR(typeof(Startup).Assembly);

        //   builder.RegisterModule<ApplicationModule>();
        }
        
        public static void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseAppSwagger();
           
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
