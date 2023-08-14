using com.expenses.domain.DomainModel.User;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.User;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class UserRepository : SqlLiteRepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(ExpensesContext context) : base(context)
        {
        }
    }
}
