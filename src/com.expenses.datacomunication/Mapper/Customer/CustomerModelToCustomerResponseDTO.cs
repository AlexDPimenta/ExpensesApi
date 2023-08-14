using AutoMapper;
using com.expenses.datacomunication.DTO.CustomerDTO;
using com.expenses.domain.DomainModel.Customer;

namespace com.expenses.datacomunication.Mapper.Customer
{
    public class CustomerModelToCustomerResponseDTO: Profile
    {
        public CustomerModelToCustomerResponseDTO()
        {
            CreateMap<CustomerModel, CustomerResponseDTO>();
        }
    }
}
