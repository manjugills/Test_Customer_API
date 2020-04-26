
using CustomerService.Application.Contracts.Services.V1;

using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Application.WebApi.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection @this) =>
            @this
                .AddTransient<ICustomerService, CustomerService.Application.Services.V1.CustomerService>();

    }
}
