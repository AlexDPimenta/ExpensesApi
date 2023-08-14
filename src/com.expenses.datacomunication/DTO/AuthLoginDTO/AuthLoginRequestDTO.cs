using System.ComponentModel.DataAnnotations;

namespace com.expenses.datacomunication.DTO
{
    public class AuthLoginRequestDTO
    {          
        [Required]
        public string Login { get; set; }        
        [Required]
        public string Password { get; set; }
    }
}
