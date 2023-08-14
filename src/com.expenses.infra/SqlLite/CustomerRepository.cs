using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Customer;
using com.expenses.infra.DataContext;
using com.expenses.infra.Interface.Customer;
using com.expenses.infra.SqlLite.Base;

namespace com.expenses.infra.SqlLite
{
    public class CustomerRepository : SqlLiteRepositoryBase<CustomerModel>, ICustomerRepository
    {
        private readonly ExpensesContext _context;
        public CustomerRepository(ExpensesContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersByNameAndCnpj(string name, string cnpj, CancellationToken cancellationToken) =>
            await _context.Customers.Where(c => c.LegalName.Equals(name) && c.Cnpj.Equals(cnpj)).ToListAsync();
    }
}
