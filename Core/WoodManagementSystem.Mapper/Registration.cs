using Microsoft.Extensions.DependencyInjection;
using WoodManagementSystem.Application.Interfaces.AutoMapper;

namespace WoodManagementSystem.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
