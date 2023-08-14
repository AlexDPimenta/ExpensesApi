using Microsoft.Extensions.DependencyInjection;
using com.expenses.service.Interface;
using com.expenses.service.Interface.Customer;
using com.expenses.service.Interface.Expense;
using com.expenses.service.Interface.Login;
using com.expenses.service.Interface.Report;
using com.expenses.service.Interface.Revenue;
using com.expenses.service.Interface.User;
using com.expenses.service.Services.Categorie;
using com.expenses.service.Services.Customer;
using com.expenses.service.Services.Expense;
using com.expenses.service.Services.Login;
using com.expenses.service.Services.Report;
using com.expenses.service.Services.Revenue;
using com.expenses.service.Services.User;

namespace com.expenses.service.IOC
{
    public static class ServicesDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {           
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddScoped<IRevenueService, RevenueService>();
            services.AddScoped<ICategorieService, CategorieService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
