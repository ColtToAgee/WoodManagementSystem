using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WoodManagementSystem.Application.Bases;
using WoodManagementSystem.Application.Behaviours;
using WoodManagementSystem.Application.Exceptions;

namespace WoodManagementSystem.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        //Tüm ruleları otomatik olarak bulup ekleme işlemi
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }
    }
}
