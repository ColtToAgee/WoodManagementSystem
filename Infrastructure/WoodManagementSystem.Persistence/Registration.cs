using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WoodManagementSystem.Application.Interfaces.Repositories;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;
using WoodManagementSystem.Persistence.Context;
using WoodManagementSystem.Persistence.Repositories;
using WoodManagementSystem.Persistence.UnitOfWorks;

namespace WoodManagementSystem.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<User>(opt =>
            {//Identity ayarlarını ayarladığımız kısım
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
