using System;
using System.Text.Json.Serialization;

namespace com.expenses.datacomunication.DTO.RevenueDTO
{
    public class RevenueToUpdateDTO
    {
        [JsonIgnore]
        public Guid RevenueId { get; set; }
        public Double Amount { get; set; }
        public string InvoiceId { get; set; }
        public string Description { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
