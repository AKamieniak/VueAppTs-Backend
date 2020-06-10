using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VueAppTsApi.Core.Interfaces;
using VueAppTsApi.Infrastructure;
using VueAppTsApi.Infrastructure.Data;
using VueAppTsApi.Services;

namespace VueAppTsApi.Extensions
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ApplicationSqlDb");

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    connectionString,
                    b =>
                        {
                            b.MigrationsHistoryTable("__EFMigrationsHistory", "app");
                            b.MigrationsAssembly("VueAppTsApi.Infrastructure");
                        }),
                ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                                                          {
                                                              ValidateIssuer = true,
                                                              ValidateAudience = true,
                                                              ValidateLifetime = true,
                                                              ValidateIssuerSigningKey = true,
                                                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey)),
                                                              ValidIssuer = Constants.Issuer,
                                                              ValidAudience = Constants.Audience,
                                                          };
                    });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IRepository, Repository>()
                .AddScoped<IAuthenticationService, AuthenticationService>();
            
            return services;
        }
    }
}