using System.ComponentModel.DataAnnotations;

namespace com.expenses.datacomunication.DTO.UserDTO
{
    public class UserRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
