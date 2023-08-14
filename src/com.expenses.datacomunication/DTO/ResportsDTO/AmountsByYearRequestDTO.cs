using System.ComponentModel.DataAnnotations;

namespace com.expenses.datacomunication.DTO.ResportsDTO
{
    public class AmountsByYearRequestDTO
    {
        [Required]
        public int FiscalYear { get; set; }
    }
}
