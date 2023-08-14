using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.api.Controllers.Base;
using com.expenses.datacomunication.DTO.RevenueDTO;
using com.expenses.service.Interface.Revenue;

namespace com.expenses.api.Controllers
{
    public class RevenuesController : MainController
    {
        public readonly IRevenueService _service;

        public RevenuesController(IRevenueService service)
        {
            _service = service;
        }


        [HttpPost("{customerID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateAsync(Guid customerID, [FromBody] RevenueRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            requestDTO.CustomerId = customerID;
            var revenue = await _service.CreateAsync(requestDTO, cancellationToken);
            if (revenue == null) return BadRequest();

            return Created("", revenue);
        }

        [HttpPut("{revenueID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid revenueID,[FromBody] RevenueToUpdateDTO revenueUpdate, CancellationToken cancellationToken)
        {
            revenueUpdate.RevenueId = revenueID;
            var response = await _service.UpdateAsync(revenueUpdate, cancellationToken);
            if (!response)
                return BadRequest();

            return Ok();

        }

        [HttpDelete("{revenueID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid revenueID, CancellationToken cancellationToken)
        {
            var response = await _service.DeleteAsync(revenueID, cancellationToken);
            if (!response)
                return BadRequest();

            return Ok();

        }
    }
}
