using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace com.expenses.datacomunication.DTO.ExpenseDTO
{
    public class ExpenseRequestDTO
    {
        [Required]
        public Double Amount { get; set; }
        [JsonIgnore]
        public Guid CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime AccrualDate { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
