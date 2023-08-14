using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Categorie;
using com.expenses.domain.DomainModel.Customer;
using com.expenses.domain.DomainModel.Expense;
using com.expenses.domain.DomainModel.Login;
using com.expenses.domain.DomainModel.Revenue;
using com.expenses.domain.DomainModel.User;
using com.expenses.infra.Interface;

namespace com.expenses.infra.DataContext
{
    public class ExpensesContext: DbContext, IUnitOfWork
    {
        public ExpensesContext(DbContextOptions<ExpensesContext> options) : base(options)
        {

        }

        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<RevenueModel> Revenues  { get; set; }
        public DbSet<CategorieModel> Categories { get; set; }
        public DbSet<ExpenseModel> Expenses { get; set; }
        public async Task saveAsync() =>
            await base.SaveChangesAsync();        
    }
}
