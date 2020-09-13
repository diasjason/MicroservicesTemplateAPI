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
        public static void AddOpenApi(this IServiceCollection services)
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
