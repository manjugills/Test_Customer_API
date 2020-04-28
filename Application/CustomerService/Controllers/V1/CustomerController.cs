using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using CustomerService.Application.Contracts.Commands.V1;
using CustomerService.Application.Contracts.Models.V1;
using CustomerService.Application.Contracts.Services.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

       
        // GET api/Customer/5
        [HttpGet(Name = "CustomerController.Get")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(CustomerReadDto), StatusCodes.Status200OK)]
        public Task<IActionResult> Get(
            [FromServices] IGetCustomerCommand command,
              string customerId,
           CancellationToken cancellationToken) =>
            command.ExecuteAsync(customerId, cancellationToken);

        [HttpPost(Name = "CustomerController.Post")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Boolean), StatusCodes.Status200OK)]
        public Task<IActionResult> Post(
            [FromServices] IPostCustomerCommand command,
            CustomerUpdateDto model,
            CancellationToken cancellationToken) =>
            command.ExecuteAsync(model, cancellationToken);

        [HttpPut(Name = "CustomerController.Put")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Boolean), StatusCodes.Status200OK)]
        public Task<IActionResult> Put(
           [FromServices] IPutCustomerCommand command,
           CustomerUpdateDto model,
           CancellationToken cancellationToken) =>
           command.ExecuteAsync(model, cancellationToken);

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
