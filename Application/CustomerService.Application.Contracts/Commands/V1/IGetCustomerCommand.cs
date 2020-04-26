using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Contracts.Commands.V1
{
    public  interface IGetCustomerCommand
    {
        Task<IActionResult> ExecuteAsync(string customerId, CancellationToken cancellationToken = default);
    }
}
