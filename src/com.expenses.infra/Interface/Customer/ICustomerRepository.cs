using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.domain.DomainModel.Customer;

namespace com.expenses.infra.Interface.Customer
{
    public interface ICustomerRepository: IRepositoryBase<CustomerModel>
    {
        Task<IEnumerable<CustomerModel>> GetCustomersByNameAndCnpj(string name, string cnpj, CancellationToken cancellationToken);
    }
}
