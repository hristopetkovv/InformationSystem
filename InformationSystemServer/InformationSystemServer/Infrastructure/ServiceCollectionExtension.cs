using InformationSystemServer.Data;
using InformationSystemServer.Services.Implementations;
using InformationSystemServer.Services.Implementations.Account;
using InformationSystemServer.Services.Implementations.Admin;
using InformationSystemServer.Services.Implementations.Helpers;
using InformationSystemServer.Services.Implementations.Report;
using InformationSystemServer.Services.Implementations.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace InformationSystemServer.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
            });
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<AppDbContext>(opt =>
             opt.UseNpgsql(connectionString));
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<UserContext>();

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, TokenConfiguration tokenConfiguration)
        {
             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.SecretKey)),
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidIssuer = tokenConfiguration.Issuer,
                     ValidAudience = tokenConfiguration.Audience
                 };
             });

            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddAuthorizationDefault(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            return services;
        }
    }
}
