using Core.Module.Clients.Interfaces;
using Core.Module.Clients.Service;
using Shared.Validate.Interfaces;
using Shared.Validate;
using System.Reflection;
using FluentValidation;
using Core.Module.Clients.Mapper;

namespace API
{
    public static class Service
    {
        public static void AddServices(this IServiceCollection services)
        {
            var coreAssembly = typeof(ClientMapper).Assembly;

            services.AddAutoMapper(coreAssembly);
            services.AddValidatorsFromAssembly(coreAssembly);

            services.AddScoped<IDtoService, DtoService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
