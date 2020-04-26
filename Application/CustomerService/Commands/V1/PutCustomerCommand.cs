using CustomerService.Application.Contracts.Commands.V1;
using CustomerService.Application.Contracts.Models.V1;
using CustomerService.Application.Contracts.Services.V1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.WebApi.Commands.V1
{
    public class PutCustomerCommand : IPutCustomerCommand
    {
        private readonly ICustomerService _customerService;
       

        public PutCustomerCommand(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> ExecuteAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default)
        {
     
                var customerExisting = await _customerService
                    .GetAsync(model.PersonalNumber, cancellationToken)
                    .ConfigureAwait(false);

                if (customerExisting == null )
                {
                    return new NoContentResult();
                }

                var cutomer = await _customerService
                    .UpdateAsync(model, cancellationToken)
                    .ConfigureAwait(false);

                return new OkObjectResult(cutomer);

        }
    }
}