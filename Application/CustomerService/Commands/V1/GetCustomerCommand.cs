using CustomerService.Application.Contracts.Commands.V1;
using CustomerService.Application.Contracts.Services.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.WebApi.Commands.V1
{
    public class GetCustomerCommand : IGetCustomerCommand
    {
        private readonly ICustomerService _customerService;


        public GetCustomerCommand(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> ExecuteAsync(string customerId, CancellationToken cancellationToken = default)
        {


            var customerExisting = await _customerService
                 .GetAsync(customerId, cancellationToken)
                 .ConfigureAwait(false);

                if (customerExisting == null)
                {
                    return new NoContentResult();
                }
                return new OkObjectResult(customerExisting);

        }

    }
}
