using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Login;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.Login;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class LoginRepository : SqlLiteRepositoryBase<LoginModel>, ILoginRepository
    {
        private readonly ExpensesContext _ctx;
        public LoginRepository(ExpensesContext context) : base(context)
        {
            _ctx = context;
        }

        public async Task<LoginModel> GetByLogin(string login, CancellationToken cancellationToken) =>
            await _ctx.Set<LoginModel>().FirstOrDefaultAsync(c => c.Login.Equals(login));
    }
}
