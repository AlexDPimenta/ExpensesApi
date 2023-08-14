using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace com.expenses.datacomunication.DTO.CustomerDTO
{
    public class CustomerRequestDTO
    {
        [Required]
        [DisplayName("cnpj")]
        public string Cnpj { get; set; }
        [Required]
        [DisplayName("comercial_name")]
        public string ComercialName { get; set; }
        [Required]
        [DisplayName("legal_name")]
        public string LegalName { get; set; }
    }
}
