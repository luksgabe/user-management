using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using UserManagement.Domain.Interfaces.Services;
using UserManagement.Domain.Interfaces.UoW;
using UserManagement.Domain.Services;
using UserManagement.Infra.Data.Context;
using UserManagement.Infra.Data.UoW;

namespace UserManagement.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();
        }

        public static void AddAutoMapperSetup(this IServiceCollection services, IMapper mapper)
        {
            services.AddSingleton(mapper);
        }

    }
}
