using CustomerService.Application.Contracts.Models.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace CustomerService.Application.Contracts.Commands.V1
{
    public interface IPutCustomerCommand
    {
        Task<IActionResult> ExecuteAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default);
    }
}
