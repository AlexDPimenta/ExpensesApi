using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Revenue;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.Report;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class ReportRepository : SqlLiteRepositoryBase<RevenueModel>, IReportRepository
    {
        private readonly ExpensesContext _context;
        public ReportRepository(ExpensesContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RevenueModel>> GetRevenuesByYear(int year, CancellationToken cancellationToken)
            => await _context.Revenues.Where(x => x.TransactionDate.Year == year).ToListAsync();
        
    }
}
