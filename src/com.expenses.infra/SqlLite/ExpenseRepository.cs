using com.expenses.domain.DomainModel.Expense;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.Expense;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class ExpenseRepository : SqlLiteRepositoryBase<ExpenseModel>, IExpenseRepository
    {
        public ExpenseRepository(ExpensesContext context) : base(context)
        {
        }
    }
}
