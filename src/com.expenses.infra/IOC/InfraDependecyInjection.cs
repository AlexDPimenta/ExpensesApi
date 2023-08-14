using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface;
using com.expenses.infra.Interface.Categorie;
using com.expenses.infra.Interface.Customer;
using com.expenses.infra.Interface.Expense;
using com.expenses.infra.Interface.Login;
using com.expenses.infra.Interface.Report;
using com.expenses.infra.Interface.Revenue;
using com.expenses.infra.Interface.User;
using com.expenses.infra.SqlLite;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.IOC
{
    public static class InfraDependecyInjection
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {                    

            services.AddDbContext<ExpensesContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("SQLConnection"),
                    b => b.MigrationsAssembly("com.expenses.api"));
            });

            services.AddScoped(typeof(IRepositoryBase< >), typeof(SqlLiteRepositoryBase< >));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

        }
    }
}
