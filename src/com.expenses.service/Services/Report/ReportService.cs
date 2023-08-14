using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.ResportsDTO;
using com.expenses.domain.DomainModel.Revenue;
using com.expenses.infra.Interface.Report;
using com.expenses.service.Interface.Report;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        private readonly NotificationContext _notification;

        public ReportService(IReportRepository repository, NotificationContext notification)
        {
            _repository = repository;
            _notification = notification;
        }

        public async Task<AmountsByMonthDTO> GetAmountsByMonth(int year, CancellationToken cancellationToken)
        {
            var revenues = await GetRevenuesByYear(year, cancellationToken);
            if (!revenues.Any())
                return default(AmountsByMonthDTO);

            return new AmountsByMonthDTO
            {
                Revenue = revenues.Select(c => new AmountByMonth
                {
                    MonthName = c.TransactionDate.ToString("MMMM"),
                    MonthRevenue = c.Amount
                }),
                MaxRevenueAmount = revenues.Sum(c => c.Amount)
            };
        }

        public async Task<AmountsByYearDTO> GetAmountsByYear(int year, CancellationToken cancellationToken)
        {
            var revenues = await GetRevenuesByYear(year, cancellationToken);
            if(!revenues.Any())
                return default(AmountsByYearDTO);

            return new AmountsByYearDTO
            {
                TotalRevenue = revenues.Sum(c => c.Amount),
                MaxRevenueAmount = revenues.Max(c => c.Amount)
            };
        }

        private async Task<IEnumerable<RevenueModel>> GetRevenuesByYear(int year, CancellationToken cancellationToken)
        {
            var revenues = await _repository.GetRevenuesByYear(year, cancellationToken);
            if (!revenues.Any())
            {
                _notification.AddNotification("year", "Revenues not found to this year!");
                return null;
            }
            return revenues;
        }
    }
}
