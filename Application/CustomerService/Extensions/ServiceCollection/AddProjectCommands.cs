using CustomerService.Application.Contracts.Commands.V1;
using CustomerService.Application.WebApi.Commands.V1;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Application.WebApi.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection @this) =>
            @this
                .AddScoped<IPutCustomerCommand, PutCustomerCommand>()
          .AddScoped<IGetCustomerCommand, GetCustomerCommand>()
             .AddScoped<IPostCustomerCommand, PostCustomerCommand>();

    }
}
