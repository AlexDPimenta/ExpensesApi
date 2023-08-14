using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Revenue;

namespace com.expenses.infra.Interface.Report
{
    public interface IReportRepository: IRepositoryBase<RevenueModel>
    {
        Task<IEnumerable<RevenueModel>> GetRevenuesByYear(int year, CancellationToken cancellationToken);
    }
}
