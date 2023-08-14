using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.api.Controllers.Base;
using com.expenses.datacomunication.DTO.CustomerDTO;
using com.expenses.service.Interface.Customer;

namespace com.expenses.api.Controllers
{
    public class CustomersController : MainController
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService customerService)
        {
            _service = customerService;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerRequestDTO request, CancellationToken cancellationToken)
        {
            var customer = await _service.CreateAsync(request, cancellationToken);
            
            return Created("", customer);
        }

        [HttpPut("{customerID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid customerID,  
            [FromBody] CustomerRequestDTO request, CancellationToken cancellationToken)
        {
            var customerUpdate = await _service.UpdateAsync(customerID, request, cancellationToken);

            if (!customerUpdate)
                return NotFound();

            return Ok();
        }


        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _service.GetByIdAsync(id, cancellationToken);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("{name}&{cnpj}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]        
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByNameAndCnpjAsync(string name, string cnpj, CancellationToken cancellationToken)
        {
            var customers = await _service.GetCustomersByNameAndCnpj(name, cnpj, cancellationToken);
            
            return Ok(customers);
        }


    }
}
