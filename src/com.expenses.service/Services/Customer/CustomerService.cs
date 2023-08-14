using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using com.expenses.datacomunication.DTO.CustomerDTO;
using com.expenses.domain.DomainModel.Customer;
using com.expenses.infra.Interface.Customer;
using com.expenses.service.Interface.Customer;
using com.expenses.tools.DomainExceptions;

namespace com.expenses.service.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;

        public CustomerService(ICustomerRepository repository, IMapper mapper, NotificationContext notificationContext)
        {
            _repository = repository;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<CustomerResponseDTO> CreateAsync(CustomerRequestDTO requestDTO, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<CustomerModel>(requestDTO);
            var response = await _repository.AddAsync(request, cancellationToken);
            return new CustomerResponseDTO { Id = response.Id };
        }

        public async Task<CustomerResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<CustomerResponseDTO>( await _repository.GetByIdAsync(id, cancellationToken));

        public async Task<CustomersResponseDTO> GetCustomersByNameAndCnpj(string name, string cnpj, CancellationToken cancellationToken)
        {
            var response = await _repository.GetCustomersByNameAndCnpj(name, cnpj, cancellationToken);
            
            if(response == null && !response.Any())
            {
                _notificationContext.AddNotification("cnpj", "customers not found");
                return default(CustomersResponseDTO);
            }

            return  new CustomersResponseDTO { Count = response.Count(), Customers = _mapper.Map<IEnumerable<CustomerResponseDTO>>(response)};

        }

        public async Task<bool> UpdateAsync(Guid customerID, CustomerRequestDTO customerToUpdate, CancellationToken cancellationToken)
        {
            var customerFound = await _repository.GetByIdAsync(customerID, cancellationToken) != null;
            if(!customerFound)
            {
                _notificationContext.AddNotification("id", "customer not found");
                return false;
            }
            var customerModel = _mapper.Map<CustomerModel>(customerToUpdate);
            customerModel.Id = customerID;

            
            await _repository.UpdateAsync(_mapper.Map<CustomerModel>(customerModel), cancellationToken);

            return true;
        }
    }
}
