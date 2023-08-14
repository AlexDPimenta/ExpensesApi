using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.api.Controllers.Base;
using com.expenses.datacomunication.DTO.ExpenseDTO;
using com.expenses.service.Interface.Expense;

namespace com.expenses.api.Controllers
{
    public class ExpensesController : MainController
    {
        private readonly IExpenseService _service;

        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        [HttpPost("{categorieID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateAsync(Guid categorieID, [FromBody] ExpenseRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            requestDTO.CategoryId = categorieID;
            var expense = await _service.CreateAsync(requestDTO, cancellationToken);
            if (expense == null) return BadRequest();

            return Created("", expense);
        }

        [HttpPut("{expenseID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid expenseID, [FromBody] ExpenseToUpdateDTO requestDTO, CancellationToken cancellationToken)
        {
            requestDTO.Id = expenseID;
            var updated = await _service.UpdateAsync(requestDTO, cancellationToken);
            if (!updated) return BadRequest();

            return Ok();
        }

        [HttpDelete("{expenseID}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid expenseID, CancellationToken cancellationToken)
        {           
            var deleted = await _service.DeleteAsync(expenseID, cancellationToken);
            if (!deleted) return BadRequest();

            return Ok();
        }
    }
}
