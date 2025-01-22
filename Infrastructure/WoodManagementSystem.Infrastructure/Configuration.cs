using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WoodManagementSystem.Application.Interfaces.Algorithms;
using WoodManagementSystem.Application.Interfaces.Mails;
using WoodManagementSystem.Application.Interfaces.Tokens;
using WoodManagementSystem.Infrastructure.Algorithms.BinPacking;
using WoodManagementSystem.Infrastructure.Mails;
using WoodManagementSystem.Infrastructure.Tokens;

namespace WoodManagementSystem.Infrastructure
{
    public static class Configuration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));//AppSettings içinde oluşturduğumuz JWT ye ulaşmak için kullanıyoruz
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IBinPackingAlgorithmService,BinPackingAlgorithm>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });

        }
    }
}
