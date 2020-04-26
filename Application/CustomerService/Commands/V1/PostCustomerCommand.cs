using CustomerService.Application.Contracts.Commands.V1;
using CustomerService.Application.Contracts.Models.V1;
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
    public class PostCustomerCommand : IPostCustomerCommand
    {

        private readonly ICustomerService _customerService;


        public PostCustomerCommand(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> ExecuteAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default)
        {

            var customerExisting = await _customerService
                .GetAsync(model.PersonalNumber, cancellationToken)
                .ConfigureAwait(false);

            if (customerExisting != null)
            {
                //throw new BusinessException($"'{model.PersonalNumber}' has already been received earlier", StatusCodes.Status412PreconditionFailed);
                return new ObjectResult(StatusCodes.Status412PreconditionFailed);
            }

            var cutomer = await _customerService
                .CreateAsync(model, cancellationToken)
                .ConfigureAwait(false);

            return new OkObjectResult(cutomer);

        }
    }
}
