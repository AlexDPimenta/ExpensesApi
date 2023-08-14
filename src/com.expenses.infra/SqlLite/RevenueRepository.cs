using com.expenses.domain.DomainModel.Revenue;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.Revenue;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class RevenueRepository : SqlLiteRepositoryBase<RevenueModel>,
        IRevenueRepository
    {
        public RevenueRepository(ExpensesContext context) : base(context)
        {
        }
    }
}
