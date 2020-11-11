using AutoMapper;
using FluentValidation.AspNetCore;
using MicroservicesTemplateAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroservicesTemplateAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddDependencies();
            services.AddAutoMapper(typeof(Startup));

            services
                .AddControllers()

                .AddFluentValidation(c =>
                {
                    c.RegisterValidatorsFromAssemblyContaining<Startup>();

                    c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
                });

            services.AddHealthChecks();

            //flexible to choose 1. JWT & Fluent vs 2.JWT vs 3.Fluent
            //services.AddFluentValidation();
            //services.AddJwt();
            services.AddOpenApiDocumentWithJwtAndFluentSchema();
            
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "LocalCorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("LocalCorsPolicy");
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseExceptionHandling();
            //app.UseExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc");
                endpoints.MapControllers();
            });
        }
    }
}
