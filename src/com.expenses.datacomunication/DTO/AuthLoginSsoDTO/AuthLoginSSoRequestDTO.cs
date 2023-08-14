using System.ComponentModel.DataAnnotations;

namespace com.expenses.datacomunication.DTO
{
    public class AuthLoginSSoRequestDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string AppToken { get; set; }
    }
}
