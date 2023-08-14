using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace com.expenses.datacomunication.DTO.RevenueDTO
{
    public class RevenueRequestDTO
    {
        [JsonIgnore]
        public Guid CustomerId { get; set; }
        public Double Amount { get; set; }
        [Required]
        public string InvoiceId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
