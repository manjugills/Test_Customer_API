using CustomerService.Domain.Infrastructure;
using CustomerService.Domain.Model.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Application.WebApi.Extensions.ServiceCollection
{

    public static partial class ServiceCollectionExtensions
    {
        // services.AddTransient<iemployeeprovider>(f =&gt; new EmployeeProvider(@"Persist Security Info = False; Integrated Security = true; Initial Catalog = TimeManagement; server = Nirjhar-Tab\SQLEXPRESS"));
       

        public static IServiceCollection AddProjectRepositories(this IServiceCollection @this) =>
            @this
                .AddTransient<ICustomerRepository, CustomerRepository>();
    }
}
