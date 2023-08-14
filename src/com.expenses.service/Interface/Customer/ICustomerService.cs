using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.CustomerDTO;

namespace com.expenses.service.Interface.Customer
{
    public interface ICustomerService
    {
        Task<CustomerResponseDTO> CreateAsync(CustomerRequestDTO requestDTO, CancellationToken cancellationToken);
        Task<CustomerResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<CustomersResponseDTO> GetCustomersByNameAndCnpj(string name, string cnpj, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Guid customerID, CustomerRequestDTO customer, CancellationToken cancellationToken);
    }
}
