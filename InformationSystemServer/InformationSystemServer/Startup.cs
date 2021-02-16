using InformationSystemServer.ExtensionMethods;
using InformationSystemServer.Middleware;
using InformationSystemServer.Services.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddOptions();

            var authConfig = this.Configuration.GetSection("TokenOptions").Get<TokenConfiguration>();
            services
                .AddDatabase(this.Configuration.GetConnectionString("DefaultConnection"))
                .AddApplicationServices()
                .AddAuthentication(authConfig)
                .AddAuthorizationDefault()
                .AddSwagger()
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

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
