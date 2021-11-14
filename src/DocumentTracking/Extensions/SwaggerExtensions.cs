using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using System.Collections.Generic;
using System.Linq;

namespace DocumentTracking.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder UseAppSwagger(this IApplicationBuilder applicationBuilder)
        {
           
            applicationBuilder.UseOpenApi();
            applicationBuilder.UseSwaggerUi3();
            applicationBuilder.UseReDoc();
            return applicationBuilder;
        }

        public static IServiceCollection AddAppSwaggerGen(this IServiceCollection service)
        {
            //service.AddSwaggerDocument(document =>
            //{
            //    document.PostProcess = d =>
            //    {
            //        d.Info.Title = "Hello world!";
            //    };
            //});
            //service.AddSwaggerDocument(config =>
            //{
            //    config.PostProcess = document =>
            //    {
            //        document.Info.Version = "v1";
            //        document.Info.Title = "ToDo API";
            //        document.Info.Description = "A simple ASP.NET Core web API";
            //        document.Info.TermsOfService = "None";
            //        document.Info.Contact = new NSwag.OpenApiContact
            //        {

            //        };
            //    };

            //});
            service.AddOpenApiDocument(document =>
            {
                document.AddSecurity("bearer", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Description = "TheCodeBuzz OAuth2 Service",
                    Flows = new NSwag.OpenApiOAuthFlows()
                    {
                        Implicit = new NSwag.OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string>
                          {
                            { "read", "Read access to protected resources" },
                            { "write", "Write access to protected resources" }
                          },
                            AuthorizationUrl = "https://localhost:44333/oauth2service/secure/authorize",
                            TokenUrl = "https://localhost:44333/oauth2service/secure/token"
                        },
                    }
                });
            });
            //service.AddOpenApiDocument(configure =>
            //{
            //    configure.AddSecurity("Basic", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
            //    {
            //        Type = OpenApiSecuritySchemeType.Basic,
            //        Name = "Authorization",
            //        In = OpenApiSecurityApiKeyLocation.Header,
            //        Description = "Provide Basic Authentiation"
            //    });
            //}
            //);

            return service;
        }
    }
}