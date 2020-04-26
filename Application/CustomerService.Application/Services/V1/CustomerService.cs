using CustomerService.Application.Contracts.Models.V1;
using CustomerService.Application.Contracts.Models.V1.Extensions;
using CustomerService.Application.Contracts.Services.V1;
using CustomerService.Domain.Model.Entities;
using CustomerService.Domain.Model.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Services.V1
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerReadDto> GetAsync(string  customerId, CancellationToken cancellationToken = default)
        {
            var entity = await _customerRepository
                .GetAsync(customerId, cancellationToken)
                .ConfigureAwait(false);

            return new CustomerReadDto().MapFrom(entity);
        }

        public async Task<bool> UpdateAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default)
        {
            Customer customer = new Customer();

            return    await _customerRepository
                    .UpdateAsync(model.MapTo(customer), cancellationToken)
                    .ConfigureAwait(false);

        }
        public async Task<bool> CreateAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default)
        {
            Customer customer = new Customer();
             return  await _customerRepository
                    .CreateAsync(model.MapTo(customer), cancellationToken)
                    .ConfigureAwait(false);
        }
    }
}
