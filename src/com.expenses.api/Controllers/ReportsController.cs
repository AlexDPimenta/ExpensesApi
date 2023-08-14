using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.api.Controllers.Base;
using com.expenses.datacomunication.DTO.ResportsDTO;
using com.expenses.service.Interface.Report;

namespace com.expenses.api.Controllers
{
    public class ReportsController : MainController
    {
        private readonly IReportService _service;

        public ReportsController(IReportService service)
        {
            _service = service;
        }

        [HttpPost("total_revenue")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTotalRevenues([FromBody]AmountsByYearRequestDTO request, CancellationToken cancellationToken)
        {
            var totalAmounts = await _service.GetAmountsByYear(request.FiscalYear, cancellationToken);
            if (totalAmounts == null)
                return BadRequest();
            return Ok(totalAmounts);
        }

        [HttpPost("revenue_by_month")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetRevenueByMonth([FromBody] AmountsByYearRequestDTO request, CancellationToken cancellationToken)
        {
            var totalAmounts = await _service.GetAmountsByMonth(request.FiscalYear, cancellationToken);
            if (totalAmounts == null)
                return BadRequest();
            return Ok(totalAmounts);
        }
    }
}
