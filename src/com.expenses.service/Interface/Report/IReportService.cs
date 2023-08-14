using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.ResportsDTO;

namespace com.expenses.service.Interface.Report
{
    public interface IReportService
    {
        Task<AmountsByYearDTO> GetAmountsByYear(int year, CancellationToken cancellationToken);
        Task<AmountsByMonthDTO> GetAmountsByMonth(int year, CancellationToken cancellationToken);
    }
}
