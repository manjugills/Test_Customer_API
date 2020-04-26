using CustomerService.Application.Contracts.Models.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Contracts.Services.V1
{
   public interface ICustomerService
    {
        Task<CustomerReadDto> GetAsync(string customerId, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default);
       
    }
}
