using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.expenses.datacomunication.DTO.CustomerDTO
{
    public class CustomersResponseDTO
    {
        public int Count { get; set; }
        public IEnumerable<CustomerResponseDTO> Customers { get; set; }
    }
}
