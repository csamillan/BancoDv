using Core.Module.Clients.Interfaces;
using Core.Module.Clients.Service;
using Shared.Validate.Interfaces;
using Shared.Validate;
using FluentValidation;
using Core.Module.Clients.Mapper;
using Core.Module.Accounts.Interfaces;
using Core.Module.Accounts.Service;
using Core.Module.Transaction.Interfaces;
using Core.Module.Transaction.Service;
using Shared.Report;
using Shared.Report.Interfaces;

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
            services.AddScoped<IGenerateReport, GenerateReport>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient",
                    builder => builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddControllers();
        }
    }
}
