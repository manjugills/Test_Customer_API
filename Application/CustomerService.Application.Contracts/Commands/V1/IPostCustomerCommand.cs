using CustomerService.Application.Contracts.Models.V1;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Contracts.Commands.V1
{
    public   interface IPostCustomerCommand
    {
        Task<IActionResult> ExecuteAsync(CustomerUpdateDto model, CancellationToken cancellationToken = default);
    }
}
