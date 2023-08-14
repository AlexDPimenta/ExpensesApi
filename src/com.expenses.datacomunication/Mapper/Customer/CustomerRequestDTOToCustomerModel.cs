using AutoMapper;
using com.expenses.datacomunication.DTO.CustomerDTO;
using com.expenses.domain.DomainModel.Customer;

namespace com.expenses.datacomunication.Mapper.Customer
{
    public class CustomerRequestDTOToCustomerModel: Profile
    {
        public CustomerRequestDTOToCustomerModel()
        {
            CreateMap<CustomerRequestDTO, CustomerModel>()
                .ForMember(c => c.Id, d => d.Ignore());
        }
    }
}
