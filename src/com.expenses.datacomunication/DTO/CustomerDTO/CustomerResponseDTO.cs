using System;
using System.ComponentModel;

namespace com.expenses.datacomunication.DTO.CustomerDTO
{
    public class CustomerResponseDTO
    {
        [DisplayName("id")]
        public Guid Id { get; set; }
        [DisplayName("cnpj")]
        public string Cnpj { get; set; }
        [DisplayName("comercial_name")]
        public string ComercialName { get; set; }
        [DisplayName("legal_name")]
        public string LegalName { get; set; }
    }
}
