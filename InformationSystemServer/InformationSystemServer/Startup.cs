using InformationSystemServer.Infrastructure;
using InformationSystemServer.Middleware;
using InformationSystemServer.Services.Implementations;
using InformationSystemServer.Services.Implementations.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InformationSystemServer
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
            services.Configure<TokenConfiguration>(this.Configuration.GetSection("TokenOptions"));
            services.Configure<ReCaptchaConfiguration>(this.Configuration.GetSection("GoogleRecaptchaV3"));
            services.AddOptions();

            var authConfig = this.Configuration.GetSection("TokenOptions").Get<TokenConfiguration>();

            services
                .AddDatabase(this.Configuration.GetConnectionString("DefaultConnection"))
                .AddApplicationServices()
                .AddAuthentication(authConfig)
                .AddAuthorizationDefault()
                .AddSwagger()
                .AddControllers();

            services.AddAutoMapper(typeof(IApplicationService).Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My InformationSystem Api");
                    c.RoutePrefix = string.Empty;
                })
                .UseAuthentication()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers()
                    .RequireAuthorization();
                });
        }
    }
}
