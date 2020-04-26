using CustomerService.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Domain.Model.Repositories
{
   public interface ICustomerRepository
    {
        Task<Customer> GetAsync(string key, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
