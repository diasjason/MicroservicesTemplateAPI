using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using ZymLabs.NSwag.FluentValidation;

namespace Microsoft.AspNetCore.Builder
{
    public static class OpenApiExtension
    {
        public static void AddOpenApiDocumentWithFluentSchema(this IServiceCollection services)
        {
            services.AddOpenApiDocument((configure, serviceProvider) =>
            {
                var fluentValidationSchemaProcessor = serviceProvider.GetService<FluentValidationSchemaProcessor>();

                // Add the fluent validations schema processor
                configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);
                configure.Title = Assembly.GetEntryAssembly()?.GetName().Name;

            });

            services.AddSingleton<FluentValidationSchemaProcessor>();
        }

        public static void AddOpenApiDocumentWithJwt(this IServiceCollection services)
        {
            services.AddOpenApiDocument((configure, serviceProvider) =>
            {
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        public static void AddOpenApiDocumentWithJwtAndFluentSchema(this IServiceCollection services)
        {
            services.AddOpenApiDocument((configure, serviceProvider) =>
            {
                var fluentValidationSchemaProcessor = serviceProvider.GetService<FluentValidationSchemaProcessor>();

                // Add the fluent validations schema processor
                configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);
                configure.Title = Assembly.GetEntryAssembly()?.GetName().Name;
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            services.AddSingleton<FluentValidationSchemaProcessor>();
        }

    }
}
